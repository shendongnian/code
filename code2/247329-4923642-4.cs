    // in metadata:
    public class B 
    { 
        public void TestMethod(bool b) {}
    }
----
    
    // in source code
    interface MyInterface 
    { 
        void TestMethod(bool b = false); 
    }
    class D : B, MyInterface {}
    // Legal because D's base class has a public method 
    // that implements the interface method
