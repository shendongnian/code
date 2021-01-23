    class FooAttributeComparer : IEqualityComparer<FooAttribute>
    {
        public bool Equals(FooAttribute x, FooAttribute y)
        {
            return x.Match(y);
        }
        public int GetHashCode(FooAttribute obj)
        {
            return 0;
            // This makes lookups complexity O(n) but it could be reasonable for small lists and 
            // if you're not sure about GetHashCode() implementation to do.
            // If you want more speed you could return e.g. :
            // return obj.Field1.GetHashCode() ^ (17 * obj.Field2.GetHashCode());
        }
    }
