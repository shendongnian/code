    public abstract class BaseTenantHealthCheck : IHealthCheck
    {
    	private IHttpContextAccessor _httpContextAccessor;
    
    	public BaseTenantHealthCheck(IHttpContextAccessor httpContextAccessor)
    	{
    		_httpContextAccessor = httpContextAccessor;
    	}
    
    	protected string GetTenant()
    	{
    		return _httpContextAccessor?.HttpContext?.Request?.Query["tenant"].ToString();
    	}
    
    	protected bool IsTenantSpecificCheck() => !string.IsNullOrEmpty(GetTenant());
    
    	public abstract Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
    		CancellationToken cancellationToken = default(CancellationToken));
    }
