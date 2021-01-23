     [EnableCors(origins: "*", headers: "*", methods: "*")]
     [RoutePrefix("api/Home")] 
 
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("test")]
        public string test()
        {
           
        }
    }
