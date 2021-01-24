    class SomeClass
    {
    	private static HttpClient _httpClient = new HttpClient();
    
    	public static Task<HttpResponseMessage> GetFirstSuccessAsync(List<string> list)
    	{
    		var tasks = new List<Task<HttpResponseMessage>>();
    		foreach (var url in list) {
    			tasks.Add(_httpClient.GetAsync(url));
    		}
    
    		return WhenAnySuccess(tasks);
    	}
    
    	private static async Task<HttpResponseMessage> WhenAnySuccess(List<Task<HttpResponseMessage>> tasks)
    	{
    		while (tasks.Count > 0) {
    			Task<HttpResponseMessage> task = await Task.WhenAny(tasks);
    			if (task.Status == TaskStatus.RanToCompletion && task.Result.StatusCode == HttpStatusCode.OK) {
    				return task.Result;
    			}
    
    			tasks.Remove(task);
    		}
    
    		return null;
    	}
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		var response = SomeClass.GetFirstSuccess(new List<string> { "http://google.com", "http://microsoft.com" }).Result;
    		Console.WriteLine(response.RequestMessage.RequestUri);
    		Console.ReadKey();
    	}
    }
