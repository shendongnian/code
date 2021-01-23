    public class MultiValueDictionary<Key, Value> : Dictionary<Key, List<Value>> {
    
      public void Add(Key key, Value value) {
        List<Value> values;
        if (!this.TryGetValue(key, out values)) {
          values = new List<Value>();
          this.Add(key, values);
        }
        values.Add(value);
      }
    
    }
