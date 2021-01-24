    var maxRetryAttempts = 3;
    var pauseBetweenFailures = TimeSpan.FromSeconds(2);
    
    var retryPolicy = Policy
        .Handle<HttpRequestException>()
        .WaitAndRetryAsync(maxRetryAttempts, i => pauseBetweenFailures);
    
    try {
      await retryPolicy.ExecuteAsync(async () =>
      {
        var response = await this.httpClientWrapper.......
        response.EnsureSuccessStatusCode();
      });
    }
    catch(HttpRequestException ex)
    {
      // You've already retried 3 times and failed, do something else here
    }
    catch(Execption ex)
    {
      // You've got a non-HttpRequestException, so we didn't retry.
    }
