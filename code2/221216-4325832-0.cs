    public class Mapper<K, L, V> : Dictionary<K, V>
    {
         public V this[K key1, L Key2]
        {
            get { return  (key1 != null) ? dic[key1] : dic[Key2]; }
        }
    }
