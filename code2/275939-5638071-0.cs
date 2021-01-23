    class A 
    { 
        protected int Test; 
    } 
    
    class B:A 
    { 
        void TestMethod()
        {
             this.Test = 3; // Possible
        }
    }
