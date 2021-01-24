    [Route("api/[controller]")]
        [ApiController]
        [EnableCors("CorsPolicy")]
        public class ValuesController : ControllerBase
        {
            private IHubContext<SignalRHub> _hub;
            public ValuesController(IHubContext<SignalRHub> hub)
            {
                _hub = hub;
            }
    
            // GET api/values
            [HttpGet]
            public ActionResult<IEnumerable<string>> Get()
            {
                _hub.Clients.All.SendAsync("clientMethodName", "get all called");
                return new string[] { "value1", "value2" };
            }
    
            // GET api/values/5
            [HttpGet("{connectionId}")]
            public ActionResult<string> Get(string connectionId)
            {
                _hub.Clients.Client(connectionId).SendAsync("clientMethodName", "get called");
                return "value";
            }
        }
    }
