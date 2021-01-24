	public class XmlWrapper : IEquatable<XmlWrapper> {
        protected readonly XElement _element;
        public XmlWrapper(XElement element) {
            _element = element;
        }
        public override string ToString() {
            return return _element != null ? _element.ToString() : this.GetType().FullName;
        }
        static public bool operator ==(XmlWrapper lhs, XmlWrapper rhs) {
            return lhs.Equals(rhs);
        }
        static public bool operator !=(XmlWrapper lhs, XmlWrapper rhs) {
            return !lhs.Equals(rhs);
        }
        public override int GetHashCode() {
            return _element.GetHashCode();
        }
        public bool Equals(XmlWrapper other) {
            return !ReferenceEquals(null, other) && _element.Equals(other._element);
        }
        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            return obj is XmlWrapper && Equals((XmlWrapper)obj);
        }
	}
