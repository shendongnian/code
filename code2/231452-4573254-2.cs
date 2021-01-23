    public class ComparerByIntId<T> : IEqualityComparer<T>
        where T : class, IIntegerIdentifiable
    {
        public bool Equals(T x, T y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.Id == y.Id;
        }
        public int GetHashCode(T obj)
        {
            return base.GetHashCode();
        }
    }
