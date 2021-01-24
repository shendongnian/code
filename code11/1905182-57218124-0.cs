    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpGet("{deviceId}/{deviceAction}")]
        public IEnumerable<CosmosDBEvents> Get(string deviceId, string deviceAction)
        {
            // ...
        }
    }
