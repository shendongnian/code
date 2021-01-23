    class AEqualityComparer : IEqualityComparer<A>
    {
        public bool Equals(A x, A y)
        {
            return x == y || x.name == y.name || x.code == y.code;
        }
    
        public int GetHashCode(A x)
        {
            return -1; // impossible to compute; will negatively impact performance
        }
    }
    
    ...
    
    Dictionary<A, string> dict = new Dictionary<A, string>(new AEqualityComparer());
