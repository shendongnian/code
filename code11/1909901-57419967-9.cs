	public class SchedulerService
	{
		private readonly IServiceScopeFactory _scopeService;
		public SchedulerService(IServiceScopeFactory scopeService)
		{
			_scopeService = scopeService;
		}
		public void EnqueueOrder(Guid? recurrentId)
		{
			// Everything you ask here will be created as if was a new scope,
			// like a request in aspnet core web apps
			using (var scope = _scopeService.CreateScope())
			{
				var recurrencyService = scope.ServiceProvider.GetRequiredService<IRecurrencyService>();
				// This service, and their injected services (like the context)
				// will be created as if was the same scope
				recurrencyService.ProcessScheduledOrder(recurrentId);
			}
		}
	}
