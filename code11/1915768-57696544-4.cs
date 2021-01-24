    public sealed class TopicTaskConcurrentDictionary : IEnumerable
    {
      #region Singleton
      private volatile ConcurrentDictionary<KeyValuePair<string, string>, IDataPipesService> underlyingCollection;
      private static TopicTaskConcurrentDictionary _instance;
      private static readonly object Sync = new object();
    
      public event NotifyCollectionChangedEventHandler CollectionChanged;
    
      private TopicTaskConcurrentDictionary()
      {
        this.underlyingCollection = new ConcurrentDictionary<KeyValuePair<string, string>, IDataPipesService>();
      }
    
      public static TopicTaskConcurrentDictionary Instance
      {
        get
        {
          if (TopicTaskConcurrentDictionary._instance == null)
          {
            lock (TopicTaskConcurrentDictionary.Sync)
            {
              if (TopicTaskConcurrentDictionary._instance == null)
              {
                TopicTaskConcurrentDictionary._instance = new TopicTaskConcurrentDictionary();
              }
            }
          }
          return TopicTaskConcurrentDictionary._instance;
        }
      }
      #endregion Singleton
    
      public void TryAdd(KeyValuePair<string, string> key, IDataPipesService value)
      {
        this.underlyingCollection.TryAdd(keyValuePair, service);
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<KeyValuePair<string, string>, IDataPipesService>(key, value)));
      }
    
      public IEnumerator GetEnumerator()
      {
        foreach (KeyValuePair<KeyValuePair<string, string>, IDataPipesService> entry in this.underlyingCollection)
        {
          yield return entry;
        }
      }    
      
      private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
      {
        this.CollectionChanged?.Invoke(this, e);
      }
    }
