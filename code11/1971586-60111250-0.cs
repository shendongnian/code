    IList<string> someStringList = new List<string>
    {
    	"Entry1",
    	"Entry2",
    	"Entry3"
    };
    
    var observableCollection = new ObservableCollection<string>(someStringList);
    
    observableCollection.CollectionChanged += (sender, eventArgs) => Console.WriteLine("Something changed!");
    
    someStringList.Add("This addition cannot be seen by the ObservableCollection!");
