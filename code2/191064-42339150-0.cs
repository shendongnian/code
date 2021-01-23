    public class MyEqualityComparer<T> : IEqualityComparer<T>
    {
        Func<T, int> _hashDelegate;
        public MyEqualityComparer(Func<T, int> hashDelegate)
        {
            _hashDelegate = hashDelegate;
        }
        public bool Equals(T x, T y)
        {
            return _hashDelegate(x) == _hashDelegate(y);
        }
        public int GetHashCode(T obj)
        {
            return _hashDelegate(obj);
        }
    }
