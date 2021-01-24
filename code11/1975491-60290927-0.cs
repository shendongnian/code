    var builder = services
        .AddHttpClient("MyService", client =>
        {
            client.BaseAddress = configuration.BaseAddress;
        })
        .AddHttpMessageHandler<MySpecialHeaderDelegatingHandler>()
        .AddTypedClient<IMyServiceClient, MyServiceRestClient>();
    public class MySpecialHeaderDelegatingHandler: DelegatingHandler
    {
        private const string MySpecialHeader = "my-special-header";
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            EnsureMySpecialHeaderExists(request);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
        private static void EnsureMySpecialHeaderExists(HttpRequestMessage request)
        {
            if (request.Method != HttpMethod.Post) return;
            if (!request.Headers.Contains(AntiForgeryToken))
            {
                request.Headers.Add(MySpecialHeader, "MyHeaderValue");
            }
        }
