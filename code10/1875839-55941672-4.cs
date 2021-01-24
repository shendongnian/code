    public class TriangleComparer : IEqualityComparer<TriangleRegistryObject>
    {
        public bool Equals(TriangleRegistryObject x, TriangleRegistryObject y)
        {
            return x.x1.Equals(y.x1) 
                   && x.y1.Equals(y.y1) 
                   && x.x2.Equals(y.x2) 
                   && x.y2.Equals(y.y2) 
                   && x.x3.Equals(y.x3) 
                   && x.y3.Equals(y.y3);
        }
        public int GetHashCode(TriangleRegistryObject obj)
        {
            unchecked
            {
                var hashCode = obj.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.GetHashCode();
                return hashCode;
            }
        }
    }
