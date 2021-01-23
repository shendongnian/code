    public static class IEnumerableExtensions
    {
             
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> myEnumerable)
        {
            Random r = new Random();               
            return myEnumerable.OrderBy(x => r.Next());
        }        
    }
