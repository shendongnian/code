 cs
public static class Helper
{
	public static int Counter<T>() where T : class => Counter(typeof(T), null);
	public static int Counter(object objectToCount) 
	{
		if(objectToCount == null)
		{
			throw new ArgumentNullException(nameof(objectToCount));
		}
		
		return Counter(objectToCount.GetType(), objectToCount);
	}
	public static int Counter(Type type, object instance)
	{
		int _counter = 0;
		
		PropertyInfo[] properties = null;
		if(instance == null)
		{
			properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static);
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
				var length = array?.Length;
				
				// do s.th. with your counter
			}
		}
		return _counter;
	}
}
then you could use it like:
var x = new TestClass();
Helper.Counter(x);
Helper.Counter<TestClass>();
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
