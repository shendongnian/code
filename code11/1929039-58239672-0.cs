    public class BaseClass<TProperty> 
        where TProperty : BaseProperty
    {
        // Now we have a generic property that must be a BaseProperty
    	public TProperty Properties { get; set; }
    }
    
    public class DerivedClass : BaseClass<DerivedProperty>
    {
        // No need for any specific override here any more
    }
