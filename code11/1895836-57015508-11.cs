    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Authorize(Roles = "VALUES:READER")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    
        [Authorize(Roles = "VALUES:ADMIN")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
