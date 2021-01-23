    void Main()
    {
    	BaseModel baseModelTest = new Concrete() { Test = "test property" };
    	
    	foreach ( var property in Concrete.EnumerateProperties())
    	{
    		var value = baseModelTest.GetPropertyValue(property.Name);
    		value.Dump(); // prints "test property"
    	}
    	
    }
    
    public class EnumeratedProperty
    {
    	public string Name { get; private set; }
    	public Type Type { get; private set; }
    	public EnumeratedProperty(string PropertyName, Type PropertyType)
    	{
    		this.Name = PropertyName;
    		this.Type = PropertyType;
    	}
    }
    
    public abstract class BaseModel
    {
    	protected static IEnumerable<PropertyInfo> PropertyInfoCache { get; set; }
    	protected static IEnumerable<EnumeratedProperty> EnumeratedPropertyCache { get; set; }
    	protected BaseModel()
    	{
    		PropertyInfoCache = this.GetType().GetProperties();
    		EnumeratedPropertyCache = PropertyInfoCache.Select(p=> new EnumeratedProperty(p.Name,p.GetType()));
    	}
    	public static IEnumerable<EnumeratedProperty> EnumerateProperties()
    	{
    		return EnumeratedPropertyCache;
    	}
    	public object GetPropertyValue(string PropertyName)
    	{
    		var property = PropertyInfoCache.SingleOrDefault(i=>i.Name==PropertyName);
    		if(property!=null)
    			return property.GetValue(this,null);
    		return null;
    	}
    }
    
    public class Concrete : BaseModel
    {
    	public string Test { get; set; }
    }
