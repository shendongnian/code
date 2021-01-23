    public class A
    {
    
        public A() 
        {
            _b = DoSomething();
        }
    
        private BClass MyClassB
        {
            get { return _b; }
        }
    
        private BClass _b;
    }
