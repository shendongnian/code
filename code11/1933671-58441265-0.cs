    var maxRetryAttempts = 3;
    var pauseBetweenFailures = TimeSpan.FromSeconds(2);
    
    var retryPolicy = Policy
        .Handle<HttpRequestException>()
        .WaitAndRetryAsync(maxRetryAttempts, i => pauseBetweenFailures);
    
    await retryPolicy.ExecuteAsync(async () =>
    {
        var response = await this.httpClientWrapper.......
        response.EnsureSuccessStatusCode();
    });
