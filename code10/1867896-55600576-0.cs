    public class TestStartup : Startup
    {
        protected override void AddBarService(IServiceCollection services)
        {
            services.AddScoped(_ => new DecoratedBarService(new BarService()));
        }
    }
