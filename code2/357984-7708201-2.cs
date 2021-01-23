    class IntEventArgs : EventArgs
    {
        public IntEventArgs(int value)
        {
            Value = value;
        }
    
        public int Value { get; private set; }
    }
    
    class Legacy
    {
        public event EventHandler<IntEventArgs> NewItem;
    
        public IList<int> GetItems()
        {
            GenerateNewItemAsync();
            return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        }
    
        private void GenerateNewItemAsync()
        {
            Task.Factory.StartNew(() =>
            {
                for (var i = 0; i < 100000; ++i)
                {
                    var handler = NewItem;
                    if (handler != null) handler(this, new IntEventArgs(i));
                    Thread.Sleep(500);
                }
    	    });
        }
    }
    
    class Example
    {
        static void Main()
        {
            var legacyObject = new Legacy();
    
            legacyObject.GetItems().ToObservable()
                .Merge(
                    Observable.FromEventPattern<IntEventArgs>(legacyObject, "NewItem")
                        .Select(e => e.EventArgs.Value))
                .Subscribe(Console.WriteLine);
    
            Console.ReadLine();
        }
    }
