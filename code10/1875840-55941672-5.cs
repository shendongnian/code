    public class TriangleRegistryObject
    {
        public double x1 { get; set; }
        public double y1 { get; set; }
        public double x2 { get; set; }
        public double y2 { get; set; }
        public double x3 { get; set; }
        public double y3 { get; set; }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        protected bool Equals(TriangleRegistryObject other)
        {
            return x1.Equals(other.x1) 
                && y1.Equals(other.y1) 
                && x2.Equals(other.x2) 
                && y2.Equals(other.y2) 
                && x3.Equals(other.x3) 
                && y3.Equals(other.y3);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = x1.GetHashCode();
                hashCode = (hashCode * 397) ^ y1.GetHashCode();
                hashCode = (hashCode * 397) ^ x2.GetHashCode();
                hashCode = (hashCode * 397) ^ y2.GetHashCode();
                hashCode = (hashCode * 397) ^ x3.GetHashCode();
                hashCode = (hashCode * 397) ^ y3.GetHashCode();
                return hashCode;
            }
        }
    }
