    public static void SafeAdd<TValue>(this IDictionary<TKey, ICollection<TValue>> dict, TKey key, TValue value)
    {
         HashSet<T> container;
         if (!dict.TryGetValue(key, out container)) 
         {
             dict[key] = new HashSet<TValue>();
         }
         dict[key].Add(value);
    }
    Usage:
    var names = new Dictionary<string, ICollection<Person>>();
    names.SafeAdd("John", new Person("John"));
