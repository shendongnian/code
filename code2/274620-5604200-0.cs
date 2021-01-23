    static class EnumerableExtensions
    {
        public static int Count(this IEnumerable source)
        {
            int res = 0;
    
            foreach (var item in source)
                res++;
    
            return res;
        }
    }
