    public class A 
    {
        private Dictionary<int,A> _inner = new Dictionary<int,A>();
        public A this[int i] {
          get { return _inner[i]; }
          set { _inner[i] = value; }
        }
        private DateTime _timeStamp;
    
        public A() {}
    }
