    public class Base
    {
       public Base(Parameter p)
       {
         Init(p)
       }
    }
    
    public class Derived : Base
    {
       public Derived(Parameter p) : base(p)
       {
     
       }
    }
