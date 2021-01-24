    class NumberDetailEqualityComparer : IEqualityComparer<NumberDetail>
    {
        public static IEQualityComparer<NumberDetail> Default {get;} = new NumberDetaulEqualityComparer();
        public bool Equals(NumberDetail x, NumberDetail y)
        {
             if (x == null) return y == null;              // true if both null
             if (y == null) return false;                  // because x not null and y null
             if (Object.ReferenceEquals(x, y) return true; // because same object
             if (x.GetType() != y.GetType()) return false; // because not same type
             // by now we are out of quick checks, we need a value check
             return x.Number == y.Number
                 && x.FullName == y.FullName
                 && ...
                 // etc, such that this returns true if according your definition
                 // x and y are equal
        }
