    void Main()
    {
    	var collection = new RangeEnabledObservableCollection<int>();
    	collection.CollectionChanged += (s,e) => Console.WriteLine("Collection changed");
    	collection.InsertRange(Enumerable.Range(0,100));
    	Console.WriteLine("Collection contains {0} items.", collection.Count);	
    }
