        static public class DictionaryExtensions
        {
            // extension method to simplify accessing a dictionary 
            static public V GetValueOrDefault<K, V>(this Dictionary<K, V> dict, K key)
            {
                V value;
                dict.TryGetValue(key, out value);
                return value;
            }
        }
