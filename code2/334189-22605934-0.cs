    public static class ListExtensions
    {
        public static void SortBy<T>(this List<T> list, params Expression<Func<T, IComparable>>[] keys)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if(keys == null || !keys.Any())
                throw new ArgumentException("Must have at least one key!");
            list.Sort((x, y) => (from selector in keys 
                                 let xVal = selector.Compile()(x) 
                                 let yVal = selector.Compile()(y) 
                                 select xVal.CompareTo(yVal))
                                 .FirstOrDefault(compared => compared != 0));
        }
    }
