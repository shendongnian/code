    public class SessionPipeline
    {
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            var options = new SessionOptions
            {
                IdleTimeout = TimeSpan.FromSeconds(5),
            };
            applicationBuilder.UseSession(options);
        }
    }
    [MiddlewareFilter(typeof(SessionPipeline))]
    public class HomeController : Controller
    {
    }
