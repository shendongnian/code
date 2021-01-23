    class Foo
    {
        private IObservable<int> observable;
        private int[] latestWindow = new int[0];
    
        IDisposable slidingWindowSubscription;
        public Foo(IObservable<int> bar)
        {
            this.observable = bar;
            slidingWindowSubscription = this.observable.SlidingWindow(20).Subscribe(a =>
                {
                    latestWindow = a;
                });
        }
    
        public IEnumerable<int> MostRecentBars
        {
            get 
            {
                 return latestWindow;
            }
        }
    }
