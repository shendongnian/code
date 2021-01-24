    public class MyHttpClient
    {
    	private readonly HttpClient _httpClient;
    
    	public MyHttpClient(HttpClient client)
    	{
    		_httpClient = client;
    	}
    
    	public void SetAuthHeader(string value)
    	{
    		_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
    	}
    }
