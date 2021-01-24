    public class BaseClass
    {
       public virtual bool stopOn {get;set;} = true;
    
       public virtual bool MethodName()
       {
           return stopOn;
       }
    }
    
    public class DerivedClass : BaseClass
    {
       public override bool stopOn = false; // For property
    
       public override bool MethodName()  // For method
       {
           return stopOn;
       }
    }
