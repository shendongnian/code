`c#
RecurringJob.AddOrUpdate(() => Console.WriteLine("This job will execute once in every minute"), Cron.Minutely);
`
Maybe you have to line up the dots a bit better to write to the vs console.
There is also an admin portal that can be configured to see what is begin run and when.
I have the following setup.
Global.asax.cs
`c#
    protected void Application_Start()
    {
        HangfireJobsConfig.Register();
    }
    public class HangfireJobsConfig
    {
        public static void Register()
        {
            if (App1Config.RunHangfireService)
            {
                JobStorage.Current = new SqlServerStorage(App1Config.DefaultConnectionStringName.Split('=').Last());
                GlobalConfiguration.Configuration.UseConsole();
                RecurringJob.AddOrUpdate("RunJob1", () => RunJob1(null), Cron.MinuteInterval(App1Config.RunJob1Interval));
                RecurringJob.AddOrUpdate("RunJob2", () => RunJob2(null), Cron.MinuteInterval(App1Config.RunJob2Interval));
            }
        }
        [AutomaticRetry(Attempts = 0, Order = 1)]
        public static void RunJob1(PerformContext context)
        {
            //dostuff
        }
        [AutomaticRetry(Attempts = 0, Order = 2)]
        public static void RunJob2(PerformContext context)
        {
            //do stuff
        }
    }
`
Startup.cs
`c#
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureHangFire(app);
        }
        public void ConfigureHangFire(IAppBuilder app)
        {
            if (App1Config.RunHangfireService)
            {
                GlobalConfiguration.Configuration.UseSqlServerStorage(
                    AppiConfig.DefaultConnectionStringName.Split('=').Last());
                GlobalConfiguration.Configuration.UseConsole();
                app.UseHangfireServer();
                var options = new DashboardOptions
                {
                    AuthorizationFilters = new[]
                    {
                        new AuthorizationFilter { Roles = "Inventory" }         
                    }
                };
                app.UseHangfireDashboard("/hangfire", options);
            }
        }
    }
`
  [1]: https://crontab.guru/#*/2_*_*_*_1-5
