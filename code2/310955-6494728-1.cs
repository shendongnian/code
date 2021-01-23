    void Main()
    {
    	BaseModel baseModelTest = new Concrete() { Test = "test property" };
    	
    	foreach ( var property in baseModelTest.EnumerateProperties())
    	{
    		var value = baseModelTest.GetPropertyValue(property.Name);
    		value.Dump();
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
    	protected IEnumerable<PropertyInfo> PropertyInfoCache { get; set; }
    	protected IEnumerable<EnumeratedProperty> EnumeratedPropertyCache { get; set; }
    	protected BaseModel()
    	{
    		PropertyInfoCache = this.GetType().GetProperties();
    		EnumeratedPropertyCache = PropertyInfoCache.Select(p=> new EnumeratedProperty(p.Name,p.GetType()));
    	}
    	public IEnumerable<EnumeratedProperty> EnumerateProperties()
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
    
....
    public static class ExtensionMethods
    {
    	public static MvcHtmlString EditorForProperty(this HtmlHelper html, BaseModel Model, EnumeratedProperty property)
    	{
    		// invoke the appropriate Html.EditorFor(...) method at runtime
    		// using the type info availible in property.Type
    		return ...
    	}
    }
