    public class ProxyHttpHandler : HttpClientHandler
    {
    	private int currentProxyIndex = 0;
	private ProxyOptions proxyOptions;
	public ProxyHttpHandler(IOptions<ProxyOptions> options)
	{
		proxyOptions = options != null ? options.Value : throw new ArgumentNullException(nameof(options));
		UseProxy = true;
	}
	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var proxy = proxyOptions.Proxies[currentProxyIndex];
		var proxyResolver = new WebProxy(proxy.Host, proxy.Port)
		{
			Credentials = proxy.Credentials
		};
		Proxy = proxyResolver;
		currentProxyIndex++;
		if(currentProxyIndex >= proxyOptions.Proxies.Count)
			currentProxyIndex = 0;
		return base.SendAsync(request, cancellationToken);
	}
