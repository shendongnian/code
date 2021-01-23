    internal class FreezableInterceptor : IInterceptor, IFreezable
    {
        private bool _isFrozen;
 
        public void Freeze()
        {
            _isFrozen = true;
        }
 
        public bool IsFrozen
        {
            get { return _isFrozen; }
        }
 
        public void Intercept(IInvocation invocation)
        {
            if (_isFrozen && invocation.Method.Name.StartsWith("set_",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new ObjectFrozenException();
            }
 
            invocation.Proceed();
        }
    }
    public static TFreezable MakeFreezable<TFreezable>() 
      where TFreezable : class, new()
    {
        return _generator.CreateClassProxy<TFreezable>(new FreezableInterceptor());
    }
