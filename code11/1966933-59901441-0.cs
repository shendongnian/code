var retryPolicy = HttpPolicyExtensions
    .HandleTransientHttpError()
    .WaitAndRetryAsync(new[]
    {
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(5),
        TimeSpan.FromSeconds(10)
    });
var noOpPolicy = Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();
services.AddHttpClient(/* etc */)
    // Select a policy based on the request: retry for Get requests, noOp for other http verbs.
    .AddPolicyHandler(request => request.Method == HttpMethod.Get ? retryPolicy : noOpPolicy);
