    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly MyHttpClient _client;
        public DataController(MyHttpClient client)
        {
            _client = client;
        }
        [ValidateAuthHeader]
        public async Task<IActionResult> GetValues()
        {
            var response = await _client.GetAsync("api/values");
            var contents = await response.Content.ReadAsStringAsync();
            return new ContentResult
            {
                Content = contents,
                ContentType = "application/json",
                StatusCode = 200
            };
        }
    }
