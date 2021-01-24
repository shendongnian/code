    public class TestController : Controller
    {
        //...
        private readonly IRemoteIpService _remoteIpService;
        public TestController(IRemoteIpService remoteIpService)
        {
            //...
            _remoteIpService = remoteIpService;
        }
        
        //..
        [HttpGet]
        public IActionResult Test()
        {
            var ip = _remoteIpService.GetRemoteIpAddress();
            return Json(ip.ToString());
        }
    }
