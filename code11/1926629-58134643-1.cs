 cs
public static class Helper
{
	public static int Counter(object objectToCount)
	{
		if (objectToCount == null)
		{
			throw new ArgumentNullException(nameof(objectToCount));
		}
		var type = objectToCount.GetType();
		
		int _counter = 0;
		foreach (var property in type.GetProperties())
		{
			if (property.PropertyType.IsArray)
			{
				var array = property.GetValue(objectToCount, null) as Array;
				var lenth = array?.Length;
				
				// do s.th. with your counter
			}
		}
		return _counter;
	}
}
then you could use it like:
var x = new TestClass();
Helper.Counter(x);
