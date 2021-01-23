    public class XElementValueEqualityComparer : IEqualityComparer<XElement>
    {
        public bool Equals(XElement x, XElement y)
        {
            return x.Value.Equals(y.Value);
        }
        
        public int GetHashCode(XElement x)
        {
            return x.Value.GetHashCode();
        }
    }
