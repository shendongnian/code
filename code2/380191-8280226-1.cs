    new List<X>().Distinct(new XComparer());
    public class XComparer : IEqualityComparer<X> {
        public bool Equals(X x, X y) {
            return x.word.Equals(y.word);
        }
        public int GetHashCode(X obj) {
            return obj.word.GetHashCode();
        }
    }
    public class X {
        public string Word { get; set; }
        public int Count { get; set; }
    }
