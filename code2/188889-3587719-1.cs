    public class ParameterlessCtorDefaultValueDictionary<K, V> 
                : DefaultValueDictionary<K, V> where V : new()
    {
      public ParameterlessCtorDefaultValueDictionary(IDictionary<K, V> baseDictionary)
         : base(baseDictionary, k => new V())
      {
        ...
      }
    }
