    var ol = new ObservableCollection<int>();
    ol.CollectionChanged += (s, e) =>
    {
      if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        Console.WriteLine("Item added!");
    };
