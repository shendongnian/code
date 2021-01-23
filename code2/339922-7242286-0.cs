    class DisposableAdapter : IDisposable, IFoo
    {
       IFoo _obj;
       public DisposableAdapter(IFoo obj)
       {
          _obj = obj;
       }
    
       public void Dispose()
       {
          if (_obj is IDisposable)
            ((IDisposable)obj).Dispose();
       }     
       // copy IFoos implementations from obj
    
    }
