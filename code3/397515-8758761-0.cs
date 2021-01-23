    public class BaseClass<TContext> : IDisposable   
       where TContext : IContext
    {
    
        public TContext Context { get; private set; }
    
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    
        public BaseClass(TContext context)
        {
           this.Context = context;
        }
    }
    
    public interface IContext : IDisposable
    {
       
    }
    
    public ChildClass : BaseClass<MyContext>
    {
       public ChildClass(MyContext context)
         : base(context)
       {
       }
    }
