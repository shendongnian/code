    [Route("{name?}")]
        [ApiController]
        public class ApiController : ControllerBase
        {
            [HttpGet]
            public string Get(string name)
            {
                // do something with name 
                return name;
            }
        }
