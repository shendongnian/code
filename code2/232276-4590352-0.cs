    public class MyObject {
    
        internal MyObject() {
        }
    
        private int _counter;
    
        public int Increment() {
            return Interlocked.Increment(ref _counter);
        }
    
    }
    
    public class MyObjectProxy {
    
        private static readonly MyObject _singleton = new MyObject();
    
        public MyObjectProxy() {
        }
    
        public int Increment() {
            return _singleton.Increment();
        }
    
    }
