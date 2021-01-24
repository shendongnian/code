    // Server Side Blazor doesn't register HttpClient by default
    if (!services.Any(x => x.ServiceType == typeof(HttpClient)))
    {
    	// Setup HttpClient for server side in a client side compatible fashion
    	services.AddScoped<HttpClient>(s =>
    	{
    		var uriHelper = s.GetRequiredService<IUriHelper>();
    		return new HttpClient
    		{
    			BaseAddress = new Uri(uriHelper.GetBaseUri())
    		};
    	});
    }
* You can also use IHttpClientFactory to configure and create HttpClient instances (preferably)
Hope this helps...
