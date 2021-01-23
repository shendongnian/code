    class MultiDict<TKey, TValue> 
    {
       private Dictionary<TKey, List<TValue>> _data;
    
       public void Add(TKey k, TValue v)
       {
          if (_data.ContainsKey(k))
             _data[k].Add(v)
          else
            _data.Add(k, new List<TValue>() { v}) ;
       }
       // more members
    }
