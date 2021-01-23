    class MyClassA {
        public MyClassA() {
            // this constructor has no parameters
            Initialize();
        }
        public MyClassA(int theValue) {
             // another constructor, but this one takes a value
             Initialize(theValue);
        }
    }
    class MyClassB {
        MyClassA a = new MyClassA(42);
    }
    
