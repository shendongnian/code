    class Foo
    {
        private ReplaySubject<int> replay = new ReplaySubject<int>(20);
    
        public Foo(IObservable<int> bar)
        {
            bar.Subscribe(replay);
        }
    
        public IEnumerable<int> MostRecentBars
        {
            get
            {
                var result = new List<int>();
                replay.Subscribe(result.Add); //Replay fill in the list with buffered items on same thread
                return result;
            }
        }
    }
