    public class SomeProviderWrapper : ISomeProvider
    {
        protected ISomeProvider WrappedProvider { get; private set; }
    
        protected SomeProviderWrapper(ISomeProvider wrapped)
        {
            if (wrapped == null)
                throw new ArgumentNullException("wrapped");
    
            WrappedProvider = wrapped;
        }
    
        public virtual object GetFoo1()
        {
            return WrappedProvider.GetFoo1();
        }
    
        public virtual object GetFoo2()
        {
            return WrappedProvider.GetFoo2();
        }
    
        public virtual object GetFoo3()
        {
            return WrappedProvider.GetFoo3();
        }
    }
