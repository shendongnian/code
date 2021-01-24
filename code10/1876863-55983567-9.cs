    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly Api1Service _api1Service;
        private readonly Api2Service _api2Service;
        public MyController(Api1Service api1Service, Api2Service api2Service)
        {
            _api1Service = api1Service;
            _api2Service = api2Service;
        }
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            var result1 = await apiService1.GetApiResultAsync();
            var result2 = await apiService2.GetApiResultAsync();
        }
    }
