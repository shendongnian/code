    private static void Main()
    {
        collection.CollectionChanged += CollectionCollectionChanged1;
        collection.CollectionChanged += CollectionCollectionChanged2;
        collection.Add(1);
    }
    private static void CollectionCollectionChanged1(object sender, NotifyCollectionChangedEventArgs e)
    {
        collection.Add(2); // this line will throw exception
    }
    private static void CollectionCollectionChanged2(object sender, NotifyCollectionChangedEventArgs e)
    {
    }
