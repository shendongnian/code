    public class XElementComparer : IEqualityComparer<XElement> {
        public bool Equals(XElement x, XElement y) {
            return x.Value == y.Value;
        }
        public int GetHashCode(XElement x) {
            return x.Value.GetHashCode();
        }
    }
