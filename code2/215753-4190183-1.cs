    public class FooComparer : IEqualityComparer<Foo> {
        public static readonly FooComparer Instance = new FooComparer();
    
        private FooComparer() { }
    
        public bool Equals(Foo a, Foo b) {
            if (a == null)
                return b == null;
    
            if (b == null)
                return false;
    
            // For case-sensitivity:
            return a.Description == b.Description;
            // For case-insensitivity:
            return String.Equals(a.Description, b.Description, StringComparison.OrdinalIgnoreCase);
        }
        public int GetHashCode(Foo obj) {
            // For case-sensitivity:
            return obj.Description.GetHashCode();
            // For case-insensitivity:
            return StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Description);
        }
    }
