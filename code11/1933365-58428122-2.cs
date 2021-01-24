[Route("api/[controller]")]
public class ValuesController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ValuesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var client = _httpClientFactory.CreateClient();
        var result = await client.GetStringAsync("http://www.google.com");
        return Ok(result);
    }
}
HttpClient delegates work to a SocketClientHandler. That's what needs to be reused. HttpClientFactory produces HttpClient instances that resuse Socket handlers from a pool of socket handlers. The handlers are recyclec periodically to take care of DNS changes.
Even better, HttpClientFactory [can be combined with Polly](https://www.stevejgordon.co.uk/httpclientfactory-using-polly-for-transient-fault-handling) to add retry logic to the HttpClient instances. It does this behind the scenes by configuring the handlers. 
