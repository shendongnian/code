// All requests made with HttpClient go through its handler's SendAsync() which we mock
var handler = new Mock<HttpMessageHandler>();
var client = handler.CreateClient();
// A simple example that returns 404 for any request
handler.SetupAnyRequest()
    .ReturnsResponse(HttpStatusCode.NotFound);
// Match GET requests to an endpoint that returns json (defaults to 200 OK)
handler.SetupRequest(HttpMethod.Get, "https://example.com/api/stuff")
    .ReturnsResponse(JsonConvert.SerializeObject(model), "application/json");
// Setting additional headers on the response using the optional configure action
handler.SetupRequest("https://example.com/api/stuff")
    .ReturnsResponse(bytes, configure: response =>
    {
        response.Content.Headers.LastModified = new DateTime(2018, 3, 9);
    })
    .Verifiable(); // Naturally we can use Moq methods as well
// Verify methods are provided matching the setup helpers
handler.VerifyAnyRequest(Times.Exactly(3));
For HttpClientFactory :
var handler = new Mock<HttpMessageHandler>();
var factory = handler.CreateClientFactory();
// Named clients can be configured as well (overriding the default)
Mock.Get(factory).Setup(x => x.CreateClient("api"))
    .Returns(() =>
    {
        var client = handler.CreateClient();
        client.BaseAddress = ApiBaseUrl;
        return client;
    });
