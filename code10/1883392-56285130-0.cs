    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly HttpClient _client;
        public ValuesController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var response = await _client.GetAsync("https://localhost:44349/api/values");
            var headers = response.Headers.ToList();
            return new string[] { "value1", "value2" };
        }
