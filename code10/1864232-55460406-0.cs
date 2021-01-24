    static async Task timeoutPolicy()
    {
        var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(1, TimeoutStrategy.Pessimistic); // setup the timeout limit to be 1 sec
        HttpResponseMessage response = await timeoutPolicy.ExecuteAsync((ct) => LongOperation(), CancellationToken.None);
    } 
