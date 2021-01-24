    public async Task Execute(IJobExecutionContext context)
    {
        // this check is superfluous and can be omitted. 
        // if you want to ensure that the service locator is there, check this in the constructor.
        // with a good DI framework, it can't be null.
        if (this.serviceProvider != null)
        {
            // open the scope and dispose it after use.
			using (var serviceScope = host.Services.CreateScope())
			{
                // get the service locator from the scope.
				var services = serviceScope.ServiceProvider;
				try
				{					
					JobKey jobKey = context.JobDetail.Key;
					IEmailScheduleSendService emailScheduleSendServiceNew = services.GetRequiredService<IEmailScheduleSendService>();
					ILogger<EmailJob> logger = services.GetRequiredService<ILogger<EmailJob>>();
					logger.LogDebug($"FROM EXECUTE METHOD | {jobKey.Name} | {jobKey.Group} | START");
					await emailScheduleSendServiceNew.EmailScheduleSendAsync(context);
					logger.LogDebug($"FROM EXECUTE METHOD | {jobKey.Name} | {jobKey.Group} | END");
				}
				catch (Exception ex)
				{
					logger.LogDebug($"SOMETHING WENT WRONG!");
				}
			}
        }        
    }
