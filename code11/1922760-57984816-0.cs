    public class TestController : ControllerBase
    {
        IConfiguration _iconfiguration;
    
    
        public TestController(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }
    
        // GET: api/Interceptor        
        [HttpGet("Heartbeat")]        
        public IActionResult Get()
           {
                //Set the return DateTime for return value
                string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
                return Ok(new
                {
                    data = currentDateTime
                });
            }
    }
        
        
    //By this you will get the body parameter as well as you can return many more properties with this like status_code, message etc..
