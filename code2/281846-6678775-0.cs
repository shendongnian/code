    public abstract class MyDbContext : DbContext
    {
        protected MyDbContext(string nameOrConnectionString)
            : base(EFTracingProviderUtils.CreateTracedEntityConnection(nameOrConnectionString), true)
        {
            // enable sql tracing
            ((IObjectContextAdapter) this).ObjectContext.EnableTracing();
        }
    }
