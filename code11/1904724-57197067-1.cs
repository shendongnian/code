    public class SessionPipeline
    {
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSession();
        }
    }
    [MiddlewareFilter(typeof(SessionPipeline))]
    public class StatefulControllerBase : ControllerBase
    {
    }
