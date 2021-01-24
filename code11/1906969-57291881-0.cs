c#
public abstract class BaseProxy
{
    protected readonly HttpClient Client;
    protected BaseProxy(HttpClient client)
    {
        Client = client;
    }
    // ... other members
}
public class XProxyImplementation : BaseProxy
{
    public XProxyImplementation(HttpClient client) : base(client)
    {
    }
    // ... other members
    public Task SendRequest() // for example
    { 
         return Client.GetAsync("....");
    }
}
During the tests, you would initialize a different instance of `HttpClient`, injecting a test-friendly implementation of `HttpMessageHandler`:
c#
// you implement TestHttpMessageHandler that aids your tests
var httpClient = new HttpClient(new TestHttpMessageHandler());
var proxyUnderTest = new XProxyImplementation(httpClient);
Regarding the choice of DI container, I would vote against coupling to any specific library, because you want your library to be consumed by many different applications, and you don't want to bloat their dependencies (an application might already be using a different DI container). 
Moreover, since the code you posted is very simple, a full-blown DI container would be an overkill. In production code, you can just move your singleton `HttpClient` to a "service locator": 
c#
public static class SingletonServices
{
    public static readonly HttpClient HttpClient;
    static SingletonServices()
    {
        HttpClient = new HttpClient();
    }
}
So that when you instantiate a proxy in production code, you do this:
c#
var proxy = new XProxyImplementation(SingletonServices.HttpClient);
