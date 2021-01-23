    abstract class Parent
    {
        public int GetNo()
        {
            return GetNoImpl();
        }
        protected abstract int GetNoImpl();
    }
    class Child : Parent
    {        
        public Child()
        {
    
        }
        protected override int GetNoImpl();
        {                       
            return 2;
        }
    }
    Parent p = new Child();
    p.GetNo();
