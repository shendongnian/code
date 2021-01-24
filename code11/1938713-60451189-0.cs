    public AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
            {
                return HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                    .OrResult(r =>  r?.Headers?.RetryAfter != null)
                    .WaitAndRetryAsync(
                        3,
                        sleepDurationProvider: (retryCount, response, context) =>
                        {
                            return response.Result.Headers.RetryAfter.Delta.Value;
                        },
                        onRetryAsync: (e, ts, i, ctx) => Task.CompletedTask
                    );
            }
