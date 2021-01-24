    void Main()
       {
    	var baseProperty = new BaseProperty() { Name = "TestName" };
    	// this one is working, meaning the member Properties != null
    	var baseObject = GetObjectInstance<BaseClass, BaseProperty>(baseProperty);
    	baseObject.Properties.Dump();
    
    	var derivedProperty = new DerivedProperty() { Name = "TestName", Description = "TestDescription" };
    	// this one is not working, meaning derivedObject.Properties is always null
    	var derivedObject = GetObjectInstance<DerivedClass, DerivedProperty>(derivedProperty);
    	derivedObject.Properties.Dump();
      }
    
    public class BaseClass
    {
    	public virtual BaseProperty Properties { get; set; }
    }
    
    public class DerivedClass : BaseClass
    {
    }
    
    public class BaseProperty
    {
    	public string Name { get; set; }
    }
    
    public class DerivedProperty : BaseProperty
    {
    	public string Description { get; set; }
    }
    
    
    public TClass GetObjectInstance<TClass, TProperty>(TProperty properties)
    	where TClass : BaseClass
    	where TProperty : BaseProperty
    {
    	var myObject = Activator.CreateInstance<TClass>();
    	myObject.Properties = properties; // this member is always null
    	return myObject;
    }
