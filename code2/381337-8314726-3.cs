    public class PayComparer : IEqualityComparer<Pay>
    {
        public bool Equals(Pay x, Pay y)
        {
            if (x == y) // same instance or both null
                return true;
            if (x == null || y == null) // either one is null but not both
                return false;
    
            return x.EventId == y.EventId;
        }
    
    
        public int GetHashCode(Pay pay)
        {
            return pay != null ? pay.EventId : 0;
        }
    }
    
    ...
    
    var Result = nlist.Intersect(olist, new PayComparer());
