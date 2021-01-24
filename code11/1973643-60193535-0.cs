lang-csharp
  public class SessionService
  {
    private readonly ISession _session;
    public SessionService(IHttpContextAccessor accessor)
    {
      _session = accessor.HttpContext.Session;
    }
    public string Username
    {
      get { return _session.GetString("username"); }
      set { _session.SetString("username", value); }
    }
  }
The session wrapper then is configured as a scoped service inside of `Startup.cs`:
lang-csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddRazorPages();
  // ...
  // Register the service we use for session handling.
  services.AddScoped<SessionService>();
}
Last but not least the service is injected into our page model and used to access the session through its property.
lang-csharp
  public class IndexModel : PageModel
  {
    private readonly ILogger<IndexModel> _logger;
    private readonly SessionService _session;
    public IndexModel(ILogger<IndexModel> logger, SessionService session)
    {
      _logger = logger;
      _session = session;
    }
    public void OnPost()
    {
	  // Set the session variable.
      _session.Username = "foo@bar";
    }
  }
I am posting the answer in hopes of getting feedback on my solution and also providing a reference point for others struggling with this.
