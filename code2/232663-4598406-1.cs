    public static class ArrayEqualityComparer
    {
        public static IEqualityComparer<T[]> Create<T>(
            IEqualityComparer<T> comparer)
        {
            return new ArrayEqualityComparer<T>(comparer);
        }
    }
    public sealed class ArrayEqualityComparer<T> : IEqualityComparer<T[]>
    {
        private static readonly IEqualityComparer<T[]> defaultInstance = new
            ArrayEqualityComparer<T>();
        public static IEqualityComparer<T[]> Default
        {
            get { return defaultInstance; }
        }
        private readonly IEqualityComparer<T> elementComparer;
        
        public ArrayEqualityComparer() : this(EqualityComparer<T>.Default)
        {
        }
        
        public ArrayEqualityComparer(IEqualityComparer<T> elementComparer)
        {
            this.elementComparer = elementComparer;        
        }
        
        public bool Equals(T[] x, T[] y)
        {
            if (x == y)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            if (x.Length != y.Length)
            {
                return false;
            }
            for (int i = 0; i < x.Length; i++)
            {
                if (!elementComparer.Equals(x[i], y[i]))
                {
                    return false;
                }
            }
            return true;
        }
    
        public int GetHashCode(T[] array)
        {
            if (array == null)
            {
                return 0;
            }
            int hash = 23;
            foreach (T item in array)
            {
                hash = hash * 31 + elementComparer.GetHashCode(item);
            }
            return hash;
        }
    }
