	public class LoggerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<LoggerMiddleware> _logger;
		public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}
		public async Task Invoke(HttpContext context)
		{
			var dictionary = new Dictionary<string, object>
			{
				{ "Username", context.User?.Identity?.Name; }
			};
			using (_logger.BeginScope(dictionary))
			{
				await _next(context);
			}
		}
	}
