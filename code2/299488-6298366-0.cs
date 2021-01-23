      public class ContextDictionary<TKey, TValue> : Dictionary<TKey, TValue>
      {
        public TValue this[TKey key, string context]
        {
          get
          {
            if (!this.ContainsKey(key))
            {
              throw new KeyNotFoundException(string.Format("There is no {0} that contains the key '{1}'!", context, key));
            }
            return this[key];
          }
          set { this[key] = value; }
        }
      }
