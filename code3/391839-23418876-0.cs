    public static void InsertRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
    {
      var enumerable = items as List<T> ?? items.ToList();
      if (collection == null || items == null || !enumerable.Any())
      {
        return;
      }
      Type type = collection.GetType();
      type.InvokeMember("CheckReentrancy", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic, null, collection, null);
      var itemsProp = type.BaseType.GetProperty("Items", BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
      var privateItems = itemsProp.GetValue(collection) as IList<T>;
      foreach (var item in enumerable)
      {
        privateItems.Add(item);
      }
      type.InvokeMember("OnPropertyChanged", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic, null,
        collection, new object[] { new PropertyChangedEventArgs("Count") });
      type.InvokeMember("OnPropertyChanged", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic, null,
        collection, new object[] { new PropertyChangedEventArgs("Item[]") });
      type.InvokeMember("OnCollectionChanged", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic, null, 
        collection, new object[]{ new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)});
    }
