    class MyService : IDisposable
    {
       private ILifetimeScope _scope;
       public MyService(ILifetimeScope scope)
       { 
          _scope = scope;
       }
    
       public void Dispose()
       {
         if(_scope is object)
         { 
            var localScope = _scope;
            _scope = null;
            // calling Dispose on the scope will also
            // call Dispose on the service again.
            localScope.Dispose();
         }
       }
    }
