     public static void AddRange<T, K>(this Hashtable hash, IEnumerable<KeyValuePair<T,K>> ikv)
     {
         if (!hash.ContainsKey(kvp.Key))
         {
            hash.Add(kvp.Key, kvp.Value);                    
         }  
     }
