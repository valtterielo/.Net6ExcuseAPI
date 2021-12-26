using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcuseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcuseController : ControllerBase
    {
        private static List<Excuse> excuses = new List<Excuse>();

        [HttpGet]
        public async Task<ActionResult<List<Excuse>>> Get()
        {
            return Ok(excuses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Excuse>> Get(int id)
        {
            var excuse = excuses.Find(e => e.Id == id);
            if (excuse == null)
                return BadRequest("Could not find an excuse");
            return Ok(excuse);
        }

        [HttpPost]
        public async Task<ActionResult<List<Excuse>>> AddExcuse(Excuse excuse)
        {
            excuses.Add(excuse);
            return Ok(excuses);
        }

        [HttpPut]
        public async Task<ActionResult<List<Excuse>>> UpdateExcuse(Excuse req)
        {
            var excuse = excuses.Find(e => e.Id == req.Id);
            if (excuse == null)
                return BadRequest("Could not find an excuse to be modified");
            excuse.ExcuseBody = req.ExcuseBody;
            return Ok(excuse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Excuse>>> DeleteExcuse(int id)
        {
            var excuse = excuses.Find(e => e.Id == id);
            if (excuse == null)
                return BadRequest("Could not find an excuse to be deleted");
            excuses.Remove(excuse);
            return Ok(excuses);
        }

    }
}
