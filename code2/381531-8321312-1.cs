    public class OneShotEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> source;
        private bool shouldThrow = false;
    
        public OneShotEnumerable(IEnumerable<T> source)
        {
            this.source = source;
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            if (shouldThrow) 
                throw new InvalidOperationException("This enumerable has already been enumerated.");
            shouldThrow = true;
    
            return this.source.GetEnumerator();
        }
    }
    public static clas OneShotEnumerableExtension
    {
        public static IEnumerable<T> SingleUse<T>(this IEnumerable<T> source)
        {
    #if (DEBUG)
            return new OneShotEnumerableExtension(source);
    #else
            return source;
    #endif
        }
    }
