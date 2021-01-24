    public class BaseClass
    {
       public virtual bool stopOn {get;set;} = true;
    }
        
    public class DerivedClass : BaseClass
    {
        public DerivedClass(){
                 stopOn = false;
        }
    }
