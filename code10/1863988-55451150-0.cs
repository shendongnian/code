    class AEqualityComparer : IEqualityComparer<A>
    {
        public bool Equals(A x, A y)
        {
            return x.Equals(y);
        }
        public int GetHashCode(A obj)
        {
            return obj.GetHashCode();
        }
    }
    var dict = new Dictionary<A, object>(new AEqualityComparer());
