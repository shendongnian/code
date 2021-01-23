    public class A {
        public A(X, Y, Z) {
        ...
        }
    }
    
    public class B : A {
        private Z calculateZ()
        {
        }
    
        public B(X, Y) : base(X, Y, calculateZ()) {
    
        }
    }
