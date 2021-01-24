cs
namespace myAPI 
{
  public class WebApiApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
       string connString = ConfigurationManager.ConnectionStrings["myContext"].ToString();
       Hangfire.GlobalConfiguration.Configuration.UseConsole();
       Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage(connString,
       new SqlServerStorageOptions {
             CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
             SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
             QueuePollInterval = TimeSpan.Zero,
             UseRecommendedIsolationLevel = true,
             UsePageLocksOnDequeue = true,
             DisableGlobalLocks = true
           });
        var bgndJS = new BackgroundJobServer(); // <--- this is essential!
        RecurringJob.AddOrUpdate("myRecurringJob", () => HangfireRecurringJob(), "*/2 * * * 1-5");
        System.Diagnostics.Debug.WriteLine("---> RecurringJob 'myHangfireJob' initated.");
    }
    public void HangfireRecurringJob() {
       System.Diagnostics.Debug.WriteLine("---> HangfireRecurringJob() executed at" + DateTime.Now);
       Console.Beep(); // <-- I was really happy to hear the beep
    }
  }
}
