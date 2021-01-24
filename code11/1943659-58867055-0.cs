    public static IAsyncPolicy<HttpResponseMessage> CreateDefaultRetryPolicy()
    {
        var timeoutPolicy = Policy.TimeoutAsync(TimeSpan.FromSeconds(180));
        var waitAndRetryPolicy = Polly.Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)),
                (result, timeSpan, context) =>
                {
                });
        return timeoutPolicy.WrapAsync(waitAndRetryPolicy);
    }
