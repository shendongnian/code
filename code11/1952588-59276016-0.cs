    public class TenantContextInitializerFilter<T> : IFilter<T> where T : class, ConsumeContext
	{
		private readonly Func<string, IDbConnection> _dbContextAccessor;
		public void Probe(ProbeContext context) { }
		public TenantContextInitializerFilter(Func<string, IDbConnection> dbContextAccessor)
		{
			_dbContextAccessor = dbContextAccessor;
		}
		public async Task Send(T context, IPipe<T> next)
		{
			var tenantId = ""; // place holder
			using (var dbContext = _dbContextAccessor(tenantId))
			{
				//... do db logic
			}
			await next.Send(context);
		}
	}
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IConnectionStringProvider>(
				provider => null /* TODO figure out how to fetch scoped instance from a cache or some storage mechanism*/);
			services.AddScoped(provider =>
			{
				IDbConnection Accessor(string tenantId)
				{
					if (provider.GetService<IConnectionStringProvider>()
						.TryGetConnectionString(tenantId, out var connectionString, out var providerName))
						return new SqlConnection(connectionString);
					throw new Exception();
				}
				return (Func<string, IDbConnection>)Accessor;
			});
		}
	}
