    public abstract class BaseClass<TContext> : IDisposable 
        where TContext : DbContext
    {
        //not abstract
        protected TContext Context { get; private set; }
    }
    
    public class DerivedClass : BaseClass<DerivedContext>
    {
        ....
    }
