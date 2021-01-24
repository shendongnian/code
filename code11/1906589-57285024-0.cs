public void ConfigureServices(IServiceCollection services)
{
    services.AddLogging(x =>
    {
        x.ClearProviders();
        x.AddSerilog(dispose: true);
    });
    
    ...
Or, as an alternative to injecting, if you just want a reference to the Serilog logger, `Serilog.Log` has a static method `Log` to create a logger...
...
using Serilog;
...
namespace Test.Controllers
{
    public class TestController : Controller
    {
        private readonly static ILogger log = Log.ForContext(typeof(TestController));
        public TestController()
        {
            log.Debug("Test");
        }
