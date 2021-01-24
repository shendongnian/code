    TopicTaskConcurrentDictionary.Instance.CollectionChanged += delegate (object o, NotifyCollectionChangedEventArgs e)
    {
      foreach (KeyValuePair<KeyValuePair<string, string>, IDataPipesService> item in TopicTaskConcurrentDictionary.Instance)
      {
        ;
      }
    };
    var dataService = _kernel.Get<IDataService>();
    TopicTaskConcurrentDictionary.Instance.TryAdd(new KeyValuePair<string, string>(param.TagPrefix, param.TopicName), dataService);
