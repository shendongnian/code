    public sealed class TopicTaskConcurrentDictionary : IEnumerable, IEnumerable<KeyValuePair<KeyValuePair<string, string>, IDataPipesService>>
    {
      public static TopicTaskConcurrentDictionary Instance => 
        TopicTaskConcurrentDictionary._instance.Value;
      public event NotifyCollectionChangedEventHandler CollectionChanged;    
      private ConcurrentDictionary<KeyValuePair<string, string>, IDataPipesService> underlyingCollection;
      private static readonly object Sync = new object();    
      private static readonly Lazy<TopicTaskConcurrentDictionary> _instance = 
        new Lazy<TopicTaskConcurrentDictionary>(() => new TopicTaskConcurrentDictionary());
    
      private TopicTaskConcurrentDictionary()
      {
        this.underlyingCollection = new ConcurrentDictionary<KeyValuePair<string, string>, IDataPipesService>();
      }
    
      public void TryAdd(KeyValuePair<string, string> key, IDataPipesService value)
      {
        this.underlyingCollection.TryAdd(keyValuePair, service);
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<KeyValuePair<string, string>, IDataPipesService>(key, value)));
      }
    
      public IEnumerator<KeyValuePair<KeyValuePair<string, string>, IDataPipesService>> GetEnumerator()
      {
        foreach (KeyValuePair<KeyValuePair<string, string>, IDataPipesService> entry in this.underlyingCollection)
        {
          yield return entry;
        }
      }
      IEnumerator IEnumerable.GetEnumerator()
      {
        return GetEnumerator();
      }
      
      private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
      {
        this.CollectionChanged?.Invoke(this, e);
      }
    }
