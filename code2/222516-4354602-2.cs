    class TupleAsUnorderedPairComparer : IEqualityComparer<Tuple<TFirst, TSecond>> {
        public bool Equals(Tuple<TFirst, TSecond> x, Tuple<TFirst, TSecond> y) {
            if(Object.ReferenceEquals(x, y)) {
                return true;
            }
            if(x == null || y == null) {
                return false;
            }
            return x.Item1 == y.Item1 && x.Item2 == y.Item2 ||
                   x.Item1 == y.Item2 && x.Item2 == y.Item1;
        }
        public int GetHashCode(Tuple<TFirst, TSecond> x) {
            if(x == null) {
                return 0;
            }
            return x.Item1.GetHashCode() ^ x.Item2.GetHashCode();
        }
    }
