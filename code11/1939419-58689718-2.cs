cs
        requestMessage.Properties[WebAssemblyHttpMessageHandler.FetchArgs] = new
        { 
            credentials = FetchCredentialsOption.Include
        };
ex:
cs
@using System.Net.Http
@using System.Net.Http.Headers
@inject HttpClient Http
@code {
    private async Task PostRequest()
    {
        Http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "{OAUTH TOKEN}");
        var requestMessage = new HttpRequestMessage()
        {
            Method = new HttpMethod("POST"),
            RequestUri = new Uri("https://localhost:10000/api/TodoItems"),
            Content = 
                new StringContent(
                    @"{""name"":""A New Todo Item"",""isComplete"":false}")
        };
        requestMessage.Content.Headers.ContentType = 
            new System.Net.Http.Headers.MediaTypeHeaderValue(
                "application/json");
        requestMessage.Content.Headers.TryAddWithoutValidation(
            "x-custom-header", "value");
        
        requestMessage.Properties[WebAssemblyHttpMessageHandler.FetchArgs] = new
        { 
            credentials = FetchCredentialsOption.Include
        };
        var response = await Http.SendAsync(requestMessage);
        var responseStatusCode = response.StatusCode;
        var responseBody = await response.Content.ReadAsStringAsync();
    }
}
You can set up this option globaly with `WebAssemblyHttpMessageHandlerOptions.DefaultCredentials` static proprerty.
Or you can implement a `DelegatingHandler` and set it up in DI with the HttpClientFactory:
cs
    public class CustomWebAssemblyHttpMessageHandler : WebAssemblyHttpMessageHandler
    {
        internal new Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
    public class CustomDelegationHandler : DelegatingHandler
    {
        private readonly CustomWebAssemblyHttpMessageHandler _innerHandler;
        public CustomDelegationHandler(CustomWebAssemblyHttpMessageHandler innerHandler)
        {
            _innerHandler = innerHandler ?? throw new ArgumentNullException(nameof(innerHandler));
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Properties[WebAssemblyHttpMessageHandler.FetchArgs] = new
            {
                credentials = "include"
            };
            return _innerHandler.SendAsync(request, cancellationToken);
        }
    }
In `Setup.ConfigureServices`
cs
services.AddTransient<CustomWebAssemblyHttpMessageHandler>()
    .AddTransient<WebAssemblyHttpMessageHandler>()
    .AddTransient<CustomDelegationHandler>()
    .AddHttpClient(httpClientName)
    .AddHttpMessageHandler<CustomDelegationHandler>();
Then you can create an `HttpClient` for your API with `IHttpClientFactory.CreateClient(httpClientName)`
In your PHP code there is an issue IMO, you souhld return CORS response header in any kind of request : 
php
if ($_SERVER['REQUEST_METHOD'] == 'OPTIONS') {
    if (isset($_SERVER['HTTP_ACCESS_CONTROL_REQUEST_METHOD']))
        // may also be using PUT, PATCH, HEAD etc
        header("Access-Control-Allow-Methods: GET, POST, OPTIONS");         
    if (isset($_SERVER['HTTP_ACCESS_CONTROL_REQUEST_HEADERS']))
        header("Access-Control-Allow-Headers: {$_SERVER['HTTP_ACCESS_CONTROL_REQUEST_HEADERS']}");
    exit(0);
}
So you should'nt do this test IMO
