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
            var subscriptions = SubscribeToValues(); // Query
            Subscriptions.AddRange(subscriptions); // Command
        }
        
        private IEnumerable<IDisposable> SubscribeToValues()
        {
            yield return MyValue1.Subscribe(
                value => DoSomething1(value), 
                ex => Log.Error(ex, ex.Message), 
                () => OnCompleted()); 
            yield return MyValue2.Subscribe(
                value => DoSomething2(value),
                ex => Log.Error(ex, ex.Message), 
                () => OnCompleted()); 
        }
        private void DoSomething1(string value){ /* ... */ }
        private void DoSomething2(string value){ /* ... */ }
        private void OnCompleted() { /* ... */ }
