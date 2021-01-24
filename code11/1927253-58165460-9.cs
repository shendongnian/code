    public class SharedStaticValue<T>
    {
      static private class Collector
      {
        static private readonly object locker = new object();
        static private readonly Dictionary<Guid, object> _Values
            = new Dictionary<Guid, object>();
        static internal void SetValue<T>(Guid key, T value)
        {
          lock ( locker )
            if ( _Values.ContainsKey(key) )
              _Values[key] = value;
            else
              _Values.Add(key, value);
        }
        static internal T GetValue<T>(Guid key)
        {
          lock ( locker )
            if ( _Values.ContainsKey(key) )
              return (T)_Values[key];
            else
            {
              T value = default(T);
              _Values.Add(key, value);
              return value;
            }
        }
      }
      private readonly Guid ID;
      public T Value
      {
        get { return Collector.GetValue<T>(ID); }
        set { Collector.SetValue(ID, value); }
      }
      public override string ToString()
      {
        return Value.ToString();
      }
      public SharedStaticValue(Guid id)
      {
        ID = id;
      }
    }
