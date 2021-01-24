private static Func<string, string, IHttpClient> GetHttpClientFactory(IComponentContext c)
{
	var context = c.Resolve<IComponentContext>();
	return (u, p) => context.Resolve<IHttpClient>(new NamedParameter("username", u), new NamedParameter("password", p));
}
...
builder.RegisterType<HttpClient>()
	.As<IHttpClient>()
	.WithParameter(new NamedParameter("serverAddress", "https://server.address.com"));
builder.Register(GetHttpClientFactory)
	.As<Func<string, string, IHttpClient>>();
Your usage might then look something like this:
public class Page
{
	private readonly Func<string, string, IHttpClient> _httpClientFactory;
	public Page(Func<string, string, IHttpClient> httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}
	public void DoHttpStuff()
	{
		// extract the user http credentials from the logged-in identity here / handle cases where they're not available:
		var user = "SomeUser";
		var password = "SomePassword";
		var client = _httpClientFactory(user, password);
        // use the client
	}
}
There are ways you could take this further and try to read the http credentials from the user context as part of the Autofac registration but it probably just adds a lot of unnecessary complication if something like the above works for your scenario.
