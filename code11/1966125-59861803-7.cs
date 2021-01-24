    public TValue this[TKey key]
    {
      get
      {
        if (!TryGetValue(key, out TValue value))
        {
          throw new KeyNotFoundException();
        }
        return value;
      }     
      set
      {
        if (key == null) throw new ArgumentNullException("key");
                
        TryAddInternal(key, value, true, true, out TValue dummy);
      }
    }
    
