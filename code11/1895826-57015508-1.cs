    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Authorize(Roles = "Values-Reader")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    
        [Authorize(Roles = "Values-Admin")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
