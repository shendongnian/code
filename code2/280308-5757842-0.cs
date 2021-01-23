    public class C {
        private ObjectId id;
        private int x;
        public C(ObjectId id, int x) {
            this.id = id;
            this.x = x;
        }
        public ObjectId Id { get { return id; } }
        public int X { get { return x; } }
    }
