    public class BaseClient
    {
    	private static readonly HttpClient _httpClient = new HttpClient();
    
    	static BaseClient()
    	{
    	}
    
    	public BaseClient(string serviceAddress, string apiKeyRequestHeader, string apiKeyValue)
    	{
    		InitializeClient(serviceAddress, apiKeyValue, apiKeyRequestHeader);
    	}
    
    	private void InitializeClient(string baseAddress, string apiKeyRequestHeaderValue, string apiKeyRequestHeader)
    	{
    		_httpClient.BaseAddress = new Uri(baseAddress);
    		_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    		_httpClient.Timeout = TimeSpan.FromMinutes(3);
    
    		if (!string.IsNullOrEmpty(apiKeyRequestHeaderValue))
    		{
    			_httpClient.DefaultRequestHeaders.Add(apiKeyRequestHeader, apiKeyRequestHeaderValue);
    		}
    	}
    }
