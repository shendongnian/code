    class UnorderedTuple<T1, T2> {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public UnorderedTuple(T1 item1, T2 item2) {
            this.Item1 = item1;
            this.Item2 = item2;
        }
        public override bool Equals(object obj) {
            if (Object.ReferenceEquals(this, obj)) {
                return true;
            }
            UnorderedTuple<T1, T2> instance = obj as UnorderedTuple<T1, T2>;
            if (instance == null) {
                return false;
            }
            return (this.Item1.Equals(instance.Item1) &&
                    this.Item2.Equals(instance.Item2)) ||
                   (this.Item1.Equals(instance.Item2) &&
                    this.Item2.Equals(instance.Item1)
                   );
        }
        public override int GetHashCode() {
            return this.Item1.GetHashCode() ^ this.Item2.GetHashCode();
        }
    }
