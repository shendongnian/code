    public class Foo {
        public String Name { 
            get{ return _Name.value; }
            set{ _Name.value = value; }
        }
        private Proxy<String> _Name;
        static void main(String[] args) {
            Foo f = new Foo();
            //will go through the logic in Proxy.
            f.Name = "test"; 
            String s = f.Name;
        }
    }
    public class Proxy<T> {
        public T value { 
            get { 
                //logic here
                return _this; 
            } set {
                //logic here
                _this = value;
            } 
        }
        private T _this;
    }
