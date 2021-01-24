    public class DistinctItemComparer : IEqualityComparer<yourClass>
    {
    
        public bool Equals(yourClass x, yourClass y)
        {
            return x.Id == y.Id &&
                x.Date == y.Date &&
                x.Card == y.Card;
        }
    
        public int GetHashCode(yourClass obj)
        {
            return obj.Id.GetHashCode() ^
                obj.Date.GetHashCode() ^
                obj.Card.GetHashCode();
        }
    }
