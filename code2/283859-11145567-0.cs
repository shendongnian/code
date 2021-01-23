    interface IA { }
    class A : IA
    {
        public static IA New() { return new A(); }
        private A() { }
        private void UseB() 
        {  
            var b = new B();
            b.HandleSomeEvent(this, null);
        }
    }
    class B
    { 
        public void HandleSomeEvent(A onlyAccess, object parameter) { }
    }
