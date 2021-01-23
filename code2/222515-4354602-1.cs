    class Pair {
        public int First { get; private set; }
        public int Second { get; private set; }
        public Pair(int first, int second) {
            this.First = first;
            this.Second = second;
        }
     
        public override bool Equals(object obj) {
            if(Object.ReferenceEquals(this, obj)) {
                return true;
            }
            Pair instance = obj as Pair;
            if(instance == null) {
                return false;
            }
            return this.First == instance.First && this.Second == instance.Second ||
                   this.First == instance.Second && this.Second == instance.First;
        }
        public override int GetHashCode() {
            return this.First.GetHashCode() ^ this.Second.GetHashCode();
        }
    }
