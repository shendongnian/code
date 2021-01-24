    public class BaseClass
    {
       public virtual bool stopOn {get;set;} = true;
    
       pubic virtual bool MethodName()
       {
           return stopOn;
       }
    }
    
    public class DerivedClass : BaseClass
    {
       public override bool stopOn = false; // for property
    
       pubic override bool MethodName()  // for method
       {
           return stopOn;
       }
    }
