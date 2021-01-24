    public sealed class TopicTaskConcurrentDictionary : IEnumerable
    {
      #region Singleton
      private volatile ConcurrentDictionary<KeyValuePair<string, string>, Table> underlyingCollection;
      private static TopicTaskConcurrentDictionary _instance;
      private static readonly object Sync = new object();
    
      public event EventHandler CollectionChanged;
    
      private TopicTaskConcurrentDictionary()
      {
        this.underlyingCollection = new ConcurrentDictionary<KeyValuePair<string, string>, Table>();
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
    
      public void TryAdd(KeyValuePair<string, string> keyValuePair, Table service)
      {
        this.underlyingCollection.TryAdd(keyValuePair, service);
        OnCollectionChanged();
      }
    
      public IEnumerator GetEnumerator()
      {
        return this.underlyingCollection.GetEnumerator();
      }
    
      private void OnCollectionChanged()
      {
        this.CollectionChanged?.Invoke(this, EventArgs.Empty);
      }
    }
