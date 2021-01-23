    public class Base
    {
        public Base(Parameter p)
        {
            Init(p)
        }
        Init(Parameter p)
        {
            // common initialisation code
        }
    }
    
    public class Derived : Base
    {
        public Derived(Parameter p) : base(p)
        {
     
        }
    }
