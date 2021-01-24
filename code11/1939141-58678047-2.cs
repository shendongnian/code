C#
void Main()
{
	var test = new test(new[] {1,2,3,4,5});
	Console.WriteLine(   test["valuesOne"][0]   ); //1
	Console.WriteLine(   test["valuesTwo"][1]   ); //4
}
public struct test 
{
	public int[] valuesOne;
	public int[] valuesTwo;
	public test(int[] data)
	{
		valuesOne = new int[2] { data[0], data[1] };
		valuesTwo = new int[2] { data[2], data[3] };
	}
	public dynamic this[string key]
	{
		get
		{
			return this.GetFieldValue(key);
		}
	}
}
public static class Extension
{
	public static object GetFieldValue(this object t, string fieldName)
	{
		var type = t.GetType();
		var fields = type.GetFields();
		var field = fields.Single(pi => pi.Name == fieldName);
		return field.GetValue(t);
	}
}
online demo link : [can-you-get-a-value-in-a-structure-through-an-outside-variable-in-c | .NET Fiddle](https://dotnetfiddle.net/8d13yq)
