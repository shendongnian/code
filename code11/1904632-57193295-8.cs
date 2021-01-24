	public class MyService(IHttpClientFactory clientFactory)
	{
        // "myServiceClient" should probably be replaced in both places with a 
        // constant (const) string value to avoid magic strings
		var httpClient = clientFactory.CreateClient("myServiceClient");
	}
