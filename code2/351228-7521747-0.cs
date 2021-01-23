    static ObservableCollection<int> myCol = new ObservableCollection<int>();
    static void Main(string[] args)
    {
      ((INotifyCollectionChanged)myCol).CollectionChanged += new NotifyCollectionChangedEventHandler(Program_CollectionChanged);
      
      ThingsCallMe(4);
      ThingsCallMe(14);
    }
    
    static void ThingsCallMe(int someImportantNumber)
    {
    	myCol.Add(someImportantNumber);
    }
    
    static void Program_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
    	Debug.WriteLine(e.NewItems.ToString());
    }
