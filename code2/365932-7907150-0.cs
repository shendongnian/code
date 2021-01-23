    public class Outer : IDisposable
    {
        private readonly Inner inner;
    
        public Outer()
        {
            inner = new Inner(new Context());
        }
    
        public void Dispose()
        {
            inner.Dispose();
        }
    }
    
    public class Inner : IDisposable
    {
        private readonly Context context;
    
        public Inner(Context context)
        {
            this.context = context;
        }
    
        public void Dispose()
        {
            context.Dispose();
        }
    }
