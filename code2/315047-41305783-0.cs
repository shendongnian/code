    public sealed MyViewModel : IDisposable
    {
        // ie. using Serilog
        private ILogger Log => Log.ForContext<MyViewModel>();
        // ie. using ReactiveProperty
        public ReactiveProperty<string> MyValue1 { get; } 
            = new ReactiveProperty<string>(string.Empty);
        
        public ReactiveProperty<string> MyValue1 { get; } 
            = new ReactiveProperty<string>(string.Empty);
        // this is basically an ICollection<IDisposable>
        private CompositeDisposable Subscriptions { get; } 
            = new CompositeDisposable();
        
        public MyViewModel()
        {
            Subscriptions.Add(MyValue1.Subscribe(value => DoSomething1(value), ex => Log.Error(ex, ex.Exception))); 
            Subscriptions.Add(MyValue2.Subscribe(value => DoSomething2(value), ex => Log.Error(ex, ex.Exception))); 
        }
        
        private void DoSomething1(string value){ /* ... */ }
        private void DoSomething2(string value){ /* ... */ }
        #region IDisposable
        private ~MyViewModel()
        {
            Dispose(false);
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
        private bool _isDisposed;
        private Dispose(bool disposing)
        {
            if(_isDisposed) return; // prevent double disposing
            MyValue1.Dispose();
            MyValue2.Dispose();
            Subscriptions.Dispose(); // dispose all at once 
            // do not suppress finalizer when called from finalizer
            if(disposing) 
            {
                // do not call finalizer when already disposed
                GC.SuppressFinalize(this);
            }
            _isDisposed = true;
        }
        #endregion
    }
