    public sealed class Outer : IDisposable
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
    
    public sealed class Inner : IDisposable
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
