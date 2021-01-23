    public static class EnumerableExtensions
    {
        public static bool ContainsNegatives(this IEnumerable<int> numbers)
        {
            foreach(n in numbers)
            {
                if(n < 0) return true;
            }
 
            return false;
        }
    }
