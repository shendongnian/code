    public class  Base
    {
    
        protected virtual string Member1()
        {
            return "";
        }
    
    }
    
    public class Derived: Base
    {
        protected override string Member1()
        {
            return "this is the ovveride";
        }
    
    }
