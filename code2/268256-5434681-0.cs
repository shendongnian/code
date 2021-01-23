    public class B
    {
        private F f;
        
        public F F
        {
            get { return f ?? (f = InitializeF()); }
            set { f = value; }
        }
        
        protected virtual F InitializeF()
        {
            return new F();
        }
    }
    
    public class X : B
    {
        protected override F InitializeF()
        {
            return new SomeOtherF();
        }
    }
