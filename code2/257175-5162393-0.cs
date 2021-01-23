    public static class EnumerableExtensions
    {
        public static bool TryGetFirst<T>(this IEnumerable<T> seq, Action<T> action)
        {
            foreach (T elem in seq)
            {
                if (action != null)
                {
                    action(elem);
                }
                
                return true;
            }
            
            return false;
        }
    }
