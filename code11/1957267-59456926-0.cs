    async Task Main()
    {
    	var polly = Policy
    		   .Handle<Exception>()		   
    		   .RetryAsync(3, (exception, retryCount, context) => Console.WriteLine($"try: {retryCount}, Exception: {exception.Message}"));
    
    	var result = await polly.ExecuteAsync(async () => await DoSomething());
    	Console.WriteLine(result);
    }
    
    int count = 0;
    
    public async Task<string> DoSomething()
    {
    	if (count < 3)
    	{
    		count++;
    		throw new Exception("boom");
    	}
    		
    	return await Task.FromResult("foo");
    }
