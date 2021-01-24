    public class SomeClass
    {
        public string PropA { get; }
        public string PropB { get; }
    }
    protected ObservableCollection<SomeClass> SomeFunc(ObservableCollection<SomeClass> collection)
    {
         
        var sorted=collection.OrderBy(s => s.PropA).ThenBy(s => s.PropB);
        ObservableCollection<SomeClass> sortedObservable=new ObservableCollection<SomeClass>();
        foreach(var item in sorted)
        {
            sortedObservable.Add(item);
        }
        return sortedObservable;
    }
