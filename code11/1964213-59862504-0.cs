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
And then apply the filter to the job
cs
public class SomeClass
{
    [LogCompletion]
    public static void YourJob() { }
}
Docs: https://docs.hangfire.io/en/latest/extensibility/using-job-filters.html
