    public static class IListExtensions
    {
        public static IList<T> SingletonList<T>(this IList<T> iList, T item)
        {        
            return Enumerable.Range(0, 1).Select(i => item).ToList();
            
            // or
            var Result = new List<T>();
            Result.Add(item);
            return Result;
        }
    }
