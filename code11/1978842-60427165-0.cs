    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            ConnectionMultiplexer connection = await ConnectionMultiplexer.ConnectAsync("redis");
            var db = connection.GetDatabase();
    
            //code to parse the XML
        }
    }
