    private static readonly ObservableCollection<int> collection = new ObservableCollection<int>();
    private static void Main()
    {
        collection.CollectionChanged += CollectionCollectionChanged;
        collection.Add(1);
    }
    private static void CollectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        collection.Add(2); // this line will throw exception
    }
