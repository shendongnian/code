    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly IEnumerable<ApiCaller> _apiCallers;
        public MyController(IEnumerable<ApiCaller> apiCallers)
        {
            _apiCallers = apiCallers;
        }
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            // Loop through one by one or call them in parallel, up to you.
            foreach(var apiCaller in _apiCallers)
            {
                var result = await apiCaller.GetApiResultAsync();
            }
        }
    }
