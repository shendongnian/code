    class Program
    {
        static void Main(string[] args)
        {
            var q = new Query<int>();
            q.CreateError();
        }
    }
    
    public class Query<TSource>
    {
        public Query()
        {    
        }
    
        public object CreateError()
        {
            Type def = typeof(DictionaryComparer<,>);
            Type t = def.MakeGenericType(new Type[] { typeof(String), typeof(object) });
            return Activator.CreateInstance(t);
        }
        class DictionaryComparer<TKey, TValue> : IEqualityComparer<IDictionary<TKey, TValue>>
        {
            public DictionaryComparer()
            {
            }
    
            public bool Equals(IDictionary<TKey, TValue> x, IDictionary<TKey, TValue> y)
            {
                if (x.Count != y.Count)
                    return false;
    
                return GetHashCode(x) == GetHashCode(y);
            }
    
            public int GetHashCode(IDictionary<TKey, TValue> obj)
            {
                int hash = 0;
                unchecked
                {
                    foreach (KeyValuePair<TKey, TValue> pair in obj)
                    {
                        int key = pair.Key.GetHashCode();
                        int value = pair.Value != null ? pair.Value.GetHashCode() : 0;
                        hash ^= key ^ value;
                    }
                }
                return hash;
            }
        }
    }
