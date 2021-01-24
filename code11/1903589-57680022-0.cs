    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/values
        [HttpPost("{val}")]
        public StatusCodeResult Post()
        {
            return Ok();
        }
    }
