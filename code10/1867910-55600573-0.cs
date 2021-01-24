    public class DBPair<T1, T2> {
        T1 v1;
        T2 v2;
        public DBPair() {
        }
        public DBPair(T1 v1, T2 v2) {
            this.v1 = v1;
            this.v2 = v2;
        }
    
        public T1 Value1
        {
            get; set;
        }
        public T2 Value2
        {
            get; set;
        }
    }
