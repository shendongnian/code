    // ------ Assembly file 1 .dll --------
    // Allow my friends (internal) and derived classes (protected) to do this. 
    public class A {
        internal protected virtual void YoBusiness() {
            //do something
        }
    }
    class B { // not a derived class - just composites an instance of A
        public B() {
            A a = new A();
            a.YoBusiness(); // Thanks friend for the access! 
        }
    }
