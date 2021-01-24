public interface IDoesSomething
{
    string GetSetting(string key);
}
public class HttpClientDoesSomething : IDoesSomething, IDisposable
{
    private readonly HttpClient _client;
    private readonly string _apiUrl;
    public HttpClientDoesSomething(string apiUrl)
    {
        _client = new HttpClient();
        _apiUrl = apiUrl;
    }
    public string GetSetting(string key)
    {
        // use the client to retrieve the setting
    }
    public void Dispose()
    {
        _client?.Dispose();
    }
}
Now the problem is moved out of your controller because you inject the interface:
public class MyController : Controller
{
    private readonly IDoesSomething _doesSomething;
    public MyController(IDoesSomething doesSomething)
    {
        _doesSomething = doesSomething;
    }
    public ActionResult Index()
    {
        var setting = _doesSomething.GetSetting("whatever"); 
        // whatever else this does.
        return View();
    }
}
Now in your startup configuration you can register `HttpClientDoesSomething` as a singleton:
    services.AddSingleton<IDoesSomething>(new HttpClientDoesSomething("url from settings"));
Your implementation is disposable, so if you do need to create and dispose it you will also dispose the `HttpClient`. But it won't be an issue because your application will keep reusing the same one.
