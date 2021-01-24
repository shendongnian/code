    public class B {
        // This should be public with eventually a private setter
        public A myA { get; private set; }    
        public B(A a) {
            myA = a;
        }
    }
    
    public class A {
    
        public B myB { get; private set; }
    
        public A() {
            myB = new B(this);
        }
    }
