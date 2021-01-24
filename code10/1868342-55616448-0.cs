    class ServiceManager : IDisposable
    {
    
        private IDisposable _startServices()
        {
            var d = new CompositeDisposable();
        
            new StartProcessX().DisposeWith(d); // those clasess should implement IDisposable and stop the work when disposed
            new StartProcessY().DisposeWith(d);
            new StartProcessZ().DisposeWith(d);
        
            return d;
        }
    
        public void StartServices()
        {
           _services = _startServices(); 
          // do some logging or whatever
        }
        
        
        public void StopServices()
        {
           _services?.Dispose(); 
        }
    
        public void Dispose()
        {
          StopServices();
        }
    }
