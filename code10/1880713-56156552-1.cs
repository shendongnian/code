     public static void AddRange<T, K>(this Hashtable hash, IEnumerable<KeyValuePair<T,K>> ikv)
     {
         foreach(KeyValuePair<T, K> kvp in ikv)
         {
            hash.Add(kvp.Key, kvp.Value);
         }
     }
