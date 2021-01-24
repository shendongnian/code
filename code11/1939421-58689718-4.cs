cs
WebAssemblyHttpMessageHandlerOptions.DefaultCredentials = FetchCredentialsOption.Include;
`WebAssemblyHttpMessageHandler` has been removed. The `HttpMessageHanlder` used is `WebAssembly.Net.Http.HttpClient.WasmHttpMessageHandler` from `WebAssembly.Net.Http` but don't include `WebAssembly.Net.Http` in your depencies or the application will failled to launch.
If you want to use the `HttpClientFactory` you can implement like that : 
cs
public class CustomDelegationHandler : DelegatingHandler
{
    private readonly IUserStore _userStore;
    private readonly HttpMessageHandler _innerHanler;
    private readonly MethodInfo _method;
   public CustomDelegationHandler(IUserStore userStore, HttpMessageHandler innerHanler)
   {
       _userStore = userStore ?? throw new ArgumentNullException(nameof(userStore));
       _innerHanler = innerHanler ?? throw new ArgumentNullException(nameof(innerHanler));
       var type = innerHanler.GetType();
       _method = type.GetMethod("SendAsync", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod) ?? throw new InvalidOperationException("Cannot get SendAsync method");
       WebAssemblyHttpMessageHandlerOptions.DefaultCredentials = FetchCredentialsOption.Include;
   }
   protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   {
        request.Headers.Authorization = new AuthenticationHeaderValue(_userStore.AuthenticationScheme, _userStore.AccessToken);            
        return _method.Invoke(_innerHanler, new object[] { request, cancellationToken }) as Task<HttpResponseMessage>;
   }
}
cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient(p =>
    {
        var wasmHttpMessageHandlerType =  Assembly.Load("WebAssembly.Net.Http")
                        .GetType("WebAssembly.Net.Http.HttpClient.WasmHttpMessageHandler");
        var constructor = wasmHttpMessageHandlerType.GetConstructor(Array.Empty<Type>());
        return constructor.Invoke(Array.Empty<object>()) as HttpMessageHandler;
    })
    .AddTransient<CustomDelegationHandler>()
    .AddHttpClient("MyApiHttpClientName")
    .AddHttpMessageHandler<CustonDelegationHandler>();
}
## 3.0 -> 3.1-preview2
On Blazor client side your need to tell to the [Fetch API](https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API) to send credentials (cookies and authorization header).
It's describe in the **Blazor doc** [Cross-origin resource sharing (CORS)](https://docs.microsoft.com/en-us/aspnet/core/blazor/call-web-api?view=aspnetcore-3.0#cross-origin-resource-sharing-cors)
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
To use the `IHttpClientFactory` you need to install `Microsoft.Extensions.Http` package.
## 3.0-preview3 => 3.0-preview9
Replace `WebAssemblyHttpMessageHandler` with `BlazorHttpMessageHandler`
