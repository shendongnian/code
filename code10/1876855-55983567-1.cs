    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly IEnumerable<ApiCaller> _apiCallers;
        public BooksAndAlbumsController(IEnumerable<ApiCaller> apiCallerS)
        {
            _apiCallers = apiCallers;
        }
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            foreach(var apiCaller in _apiCallers)
            {
                var result = await apiCaller.GetApiResultAsync();
            }
        }
    }
