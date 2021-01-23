    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("api/Home/test")]
        public string test()
        {
           return "";
        }
    }
