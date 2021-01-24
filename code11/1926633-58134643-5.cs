 cs
public static class Helper
{
	// This method will only iterate the public static properties
	public static int Counter<T>() where T : class => Counter(typeof(T), null);
	// This method will iterate all public properties
	public static int Counter<T>(T objectToCount) where T : class
	{
		if(objectToCount == null)
		{
			throw new ArgumentNullException(nameof(objectToCount));
		}
		
		return Counter(typeof(T), objectToCount);
	}
	public static int Counter(Type type, object instance)
	{
		int _counter = 0;
		
		PropertyInfo[] properties = null;
		if(instance == null)
		{
			properties = type.GetProperties(BindingFlags.Static | BindingFlags.Public);
		}
		else
		{
			properties = type.GetProperties();
		}
		foreach (var property in properties)
		{
			if (property.PropertyType.IsArray)
			{
				var array = property.GetValue(instance, null) as Array;
				var length  = array?.Length;
				
				// do s.th. with your counter
			}
		}
		return _counter;
	}
}
then you could use it like:
Helper.Counter(x);
Helper.Counter<TestClass>();
Helper.Counter<TestClass>(x);
-----
**Update:**
for only instanced objects it could be simplified to this:
 cs 
public static int Counter(object objectToCount) 
{
	if(objectToCount == null)
	{
		throw new ArgumentNullException(nameof(objectToCount));
	}
	int _counter = 0;
	foreach (var property in objectToCount.GetType().GetProperties())
	{
		if (property.PropertyType.IsArray)
		{
			var array = property.GetValue(objectToCount, null) as Array;
			var length = array?.Length;
			// do s.th. with your counter
		}
	}
	return _counter;
}
