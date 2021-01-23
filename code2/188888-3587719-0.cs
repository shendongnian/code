    public class DefaultValueDictionary<K, V> : IDictionary<K, V>
    {
      public DefaultValueDictionary(IDictionary<K, V> baseDictionary, Func<K, V> defaultValueFunc)
      {
        ...
      }
    }
