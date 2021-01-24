    public class HttpService : IHttpService
    {
    	private static HttpClient _httpClient;
    
    	private const string MimeTypeApplicationJson = "application/json";
    
    	public HttpService()
    	{
    		_httpClient = new HttpClient();
    	}
    
    	private static async Task<HttpResponseMessage> HttpSendAsync(HttpMethod method, Uri url, string payload,
    		Dictionary<string, string> headers = null)
    	{
    		var request = new HttpRequestMessage(method, url);
    		request.Headers.Add("Accept", MimeTypeApplicationJson);
    
    		if (headers != null)
    		{
    			foreach (var header in headers)
    			{
    				request.Headers.Add(header.Key, header.Value);
    			}
    		}
    
    		if (!string.IsNullOrWhiteSpace(payload))
    			request.Content = new StringContent(payload, Encoding.UTF8, MimeTypeApplicationJson);
    
    		return await _httpClient.SendAsync(request);
    	}
    
    	public async Task<HttpResponseMessage> Post(Uri url, string payload, Dictionary<string, string> headers = null)
    	{
    		return await HttpSendAsync(HttpMethod.Post, url, payload, headers);
    	}
    }
