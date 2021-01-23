    public class A {
        public A(X x, Y y, Z z) {
        ...
        }
    }
    
    public class B : A {
        private static Z calculateZ()
        {
        }
    
        public B(X x, Y y) : base(X, Y, calculateZ()) {
    
        }
    }
