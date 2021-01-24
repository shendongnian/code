cs
using Hangfire.Common;
using Hangfire.Server;
class LogCompletionAttribute : JobFilterAttribute, IServerFilter
{
    public void OnPerforming(PerformingContext filterContext)
    {
        // Code here if you care when the execution **has begun**
    }
    public void OnPerformed(PerformedContext context)
    {
        // Check that the job completed successfully
        if (!context.Canceled && context.Exception != null)
        {
            // Here you would write to your database.
            // Example with entity framework:
            using (var ctx = new YourDatabaseContext())
            {
                ctx.Something.Add(/**/);
                ctx.SaveChanges();
            }
        }
    }
}
And then apply the filter to the job method:
cs
namespace myAPI
{
   public class WebApiApplication : System.Web.HttpApplication
   {
      protected void Application_Start(
      {
         System.Diagnostics.Debug.WriteLine("Recurring job will be set up.");
         RecurringJob.AddOrUpdate("some-id", () => MyJob(), "*/2 * * * 1-5"); 
      }
	  
	  [LogCompletion]
	  public static void MyJob()
	  {
		  System.Diagnostics.Debug.WriteLine("Job instance started at " + DateTime.Now)
	  }
   }
}
Docs: https://docs.hangfire.io/en/latest/extensibility/using-job-filters.html
