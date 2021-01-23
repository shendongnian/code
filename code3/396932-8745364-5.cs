    public class Dictionary2d<TKey1, TKey2, TItem> : Dictionary<Tuple<TKey1, TKey2>,TItem>
    {
        public void Add(TKey1 k1, TKey2, TItem item) {
            this.Add(Tuple.Create(k1,k2), item);
        }
    
        public TContent this[TKey1 k1, TKey2 k2] {
            get { return this[Tuple.Create(k1,k2)]; }
        }
    }
    
    public class Program
    {
        static void Main() {
            var coll = new Dictionary2d<<int,int>, AnyClass>();
            coll.Add(2, 3, new AnyClass("foo"));
            coll.Add(4, 2, new AnyClass("bar"));
            
            var foo = coll[2,3];
            var bar = coll[4,2];
        }
    }
