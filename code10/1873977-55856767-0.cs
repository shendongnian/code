    class DbContextScope : IDisposable
    {
    	public static DbContextScope Open<TContext>(ref TContext context) where TContext : DbContext, new()
    		=> context != null ? NullScope : new DbContextScope(context = new TContext());
    	static readonly DbContextScope NullScope = new DbContextScope(null);
    	private DbContextScope(DbContext context) => this.context = context;
    	readonly DbContext context;
    	public void Dispose() => context?.Dispose();
    }
