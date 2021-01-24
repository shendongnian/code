 cs
public static class Helper
{
	public static int Counter<T>() where T : class => Counter(typeof(T));
	public static int Counter(object objectTCount) => Counter(objectTCount.GetType());
	public static int Counter(Type type)
	{
		int _counter = 0;
		foreach (var property in type.GetProperties())
		{
			if (property.PropertyType.IsArray)
			{
				var array = property.GetValue(null, null) as Array;
				var lenth = array.Length;
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
