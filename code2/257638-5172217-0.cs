    public sealed class Something<T> : Something {
      private IDictionary<T,Activity> fCases;
    
      public override IDictionary<T,Activity> Cases
      {
        get { return fCases; }
        set { fCases = value; }
      }
    
      public override IEnumerable<KeyValuPair<object, Activity>> GetElements() {
        foreach (var cur in fCases) {
          yield return new KeyValuePair<object, Activity>(cur.Key, cur.Value);
        }
      }
      
      public override bool TryGetValue(object key, out Activity activity) {
        try {
          T typedKey = (T)key;
          return fCases.TryGetValue(typedKey, out activity);
        } catch (InvalidCastException) {
          activity = null;
          return false;
        }
      }
    }
}
