    static async Task timeoutPolicy()
    {
        var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(1, TimeoutStrategy.Optimistic); // setup the timeout limit to be 1 sec
        HttpResponseMessage response = await timeoutPolicy.ExecuteAsync((ct) => LongOperation(ct), CancellationToken.None);
    }
    static Task<HttpResponseMessage> LongOperation(CancellationToken token)
    {
        return Task<HttpResponseMessage>.Factory.StartNew(() =>
        {
            var longTask = Task.Delay(5000);
            while (!longTask.IsCompleted)
            {
                token.ThrowIfCancellationRequested();
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest
            };
        });
    } 
