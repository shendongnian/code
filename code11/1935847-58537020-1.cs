    public class ScheduledEmailService : ScheduledProcessor
    	{
    		public ScheduledEmailService(
    			IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
    		{
    		}
    
    		/// <summary>
    		/// Get cron setting from db
    		/// </summary>
    		/// <returns></returns>
    		protected override string GetCronExpression(IServiceScopeFactory serviceScopeFactory)
    		{
    			return ""; // return your cron expression here you can get from db or static string
    		}
    
    		public override Task ProcessInScope(IServiceProvider serviceProvider)
    		{
    			// do something you wish
    			return Task.CompletedTask;
    		}
    	}
