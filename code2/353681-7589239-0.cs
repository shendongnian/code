    public Interface ISystem
    {
        public void GetPropertyInformation();
        //Other methods to implement
    }
    
    public abstract class System : ISystem
    {
        public virtual void GetPropertyInformation()
        {
            //Standard Code here
        }
    }
    
    public class B : System
    {  
       public string ExtendedSystemProp {get;set;}
       public override void GetPropertyInformation()
       {
          base.GetPropertyInformation();
     
          var prop = "some extra calculating";
    	  
    	  GetExtraPropertyInformation(prop);
        }
    	
    	public void GetExtraPropertyInformation(string prop)
    	{
    	     ExtendedSystemProp = prop;
    	}
    }
    ISystem genericSystem = new B();
    genericSystem.GetPropertyInformation();
    
    (genericSystem as B).ExtendedSystemProp = "value";
