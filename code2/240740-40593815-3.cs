    public partial sealed class MyControl : UserControl, IDisposable 
    {
        public MyControl()
        {
            InitializeComponent();
            
            // this is the interesting part 
            var subscription = this.Observe(MyProperty)
                                   .Subscribe(args => { /* ... */}));
            // the rest of the class is infrastructure for proper disposing
            Subscriptions.Add(subscription);
            Dispatcher.ShutdownStarted += DispatcherOnShutdownStarted; 
        }
        private IList<IDisposable> Subscriptions { get; } = new List<IDisposable>();
        private void DispatcherOnShutdownStarted(object sender, EventArgs eventArgs)
        {
            Dispose();
        }
        
        Dispose(){
            Dispose(true);
        }
        ~MyClass(){
            Dispose(false);
        }
        
        bool _isDisposed;
        void Dispose(bool isDisposing)
        {
            if(_disposed) return;
            
            foreach(var subscription in Subscriptions)
            {
                subscription?.Dispose();
            }
    
            _isDisposed = true;
            if(isDisposing) GC.SupressFinalize(this);
        }
    }
