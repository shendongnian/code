	public class CacheAttribute : InterceptAttribute
	{
		public override IInterceptor CreateInterceptor(IProxyRequest request)
		{
			return request.Context.Kernel.Get<CachingInterceptor>();
		}
	}
	public class CachingInterceptor : IInterceptor
	{
		private ICache Cache { get; set; }
		public CachingInterceptor(ICache cache)
		{
			Cache = cache;
		}
		public void Intercept(IInvocation invocation)
		{
			string className = invocation.Request.Target.GetType().FullName;
			string methodName = invocation.Request.Method.Name;
			object[] arguments = invocation.Request.Arguments;
			StringBuilder builder = new StringBuilder(100);
			builder.Append(className);
			builder.Append(".");
			builder.Append(methodName);
			arguments.ToList().ForEach(x =>
			{
				builder.Append("_");
				builder.Append(x);
			});
			string cacheKey = builder.ToString();
			object retrieve = Cache.Retrieve<object>(cacheKey);
			if (retrieve == null)
			{
				invocation.Proceed();
				retrieve = invocation.ReturnValue;
				Cache.Store(cacheKey, retrieve);
			}
			else
			{
				invocation.ReturnValue = retrieve;
			}
		}
	}
