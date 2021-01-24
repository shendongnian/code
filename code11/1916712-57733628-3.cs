    public class XmlWrapper : IEquatable<XmlWrapper> {
        protected readonly XElement _element;
        public XmlWrapper(XElement element) {
            _element = element;
        }
        static public bool operator ==(XmlWrapper lhs, XmlWrapper rhs) {
            return !ReferenceEquals(null, lhs) && lhs.Equals(rhs);
        }
        static public bool operator !=(XmlWrapper lhs, XmlWrapper rhs) {
            return !ReferenceEquals(null, lhs) && !lhs.Equals(rhs);
        }
        public override string ToString() {
            return _element != null ? _element.ToString() : this.GetType().FullName;
        }
        public override int GetHashCode() {
            return _element.GetHashCode();
        }
        public override bool Equals(object obj) {
            return obj is XmlWrapper other && Equals(other);
        }
        public bool Equals(XmlWrapper other) {
            return !ReferenceEquals(null, other) && _element.Equals(other._element);
        }
    }
