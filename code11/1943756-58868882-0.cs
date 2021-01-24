public class Program : IUserFactory
{
    public static void Main(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(s => s.AddSingleton<IUserFactory, Program>())
            .UseSentry(o => o.SendDefaultPii = true)
            .Configure(a => a.Use( (context, next) => throw null))
            .Build()
            .Run();
    public User Create(HttpContext context) => new User {Id = "works"};
}
Upon [reviewing the code in Sentry's .NET SDK][1]:
if (options?.SendDefaultPii == true && !scope.HasUser())
{
    var userFactory = context.RequestServices?.GetService<IUserFactory>();
    if (userFactory != null)
    {
        scope.User = userFactory.Create(context);
    }
}
I realize that maybe you already have a user set in the scope and for that reason the factory is not being resolved and called?
You can verify that with a callback:
.UseSentry(o =>
{
    o.BeforeSend = @event =>
    {
        if (@event.HasUser())
        {
            // ...
            @event.User = new User();
        }
        return @event;
    };
})
Or with an event processor which can be registered with DI and take dependencies:
public class UserEventProcessor : ISentryEventProcessor
{
    private readonly IUserFactory _userFactory;
    private readonly IHttpContextAccessor _accessor;
    public UserEventProcessor(IUserFactory userFactory, IHttpContextAccessor accessor)
    {
        _userFactory = userFactory;
        _accessor = accessor;
    }
    public SentryEvent Process(SentryEvent @event)
    {
        @event.User = _userFactory.Create(_accessor.HttpContext);
        return @event;
    }
}
// and register:
services.ConfigureServices(s => s.AddScoped<ISentryEventProcessor, UserEventProcessor>())
  [1]: https://github.com/getsentry/sentry-dotnet/blob/5a01c5b6371571884f7fa030b086615b4621bb87/src/Sentry.AspNetCore/ScopeExtensions.cs#L33-L40
