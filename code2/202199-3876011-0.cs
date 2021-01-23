    // ------ Assembly file 1 .dll --------
    // Allow my friends (internal) and derived classes (protected) to do this. 
    class A {
        internal protected virtual void YoMomma() {
            //do something
        }
    }
    class B {
        public B() {
            A a = new A();
            a.YoMomma(); // Thanks friend for the access! 
        }
    }
