    [ApiController]
    public class HomeController : ControllerBase
    {
        private something _sth;
        public HomeController(something sth)
        {
            _sth = sth;
        }
        [HttpGet("foo")]
        public string foo()
        {
            _sth.url = Request.Scheme + "://" + Request.Host;
            return _sth.SomethingToExecute();
        }
    }
