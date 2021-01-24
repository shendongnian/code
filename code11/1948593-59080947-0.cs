csharp
class MyClassToMap
{
	public string MyString { get; set; }
	public int MyInt { get; set; }
}
you could write a simple method...
csharp
MyClassToMap Map(params MyClassToMap[] toMap)
{
	var mapped = new MyClassToMap();
	
	foreach (var m in toMap)
	{
		// 'default' is shorthand for a type's uninitalized value. In the case of
		// string, it resolves to "null", and in the case of int, it resolves to 0.
		// You could also use the literal values here, if you prefer.
		// Note that for C# versions < 7.1, you must specify the type--eg "default(string)".
		// See: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/default
		if (m.MyString != default) mapped.MyString = m.MyString;
		if (m.MyInt != default) mapped.MyInt = m.MyInt;
	}
	
	return mapped;
}
and call it like so...
csharp
var a = new MyClassToMap { MyString = "foo", MyInt = 0 };
var b = new MyClassToMap { MyString = "bar", MyInt = 100 };
var c = new MyClassToMap { MyString = null, MyInt = 0 };
var mapped = Map(a, b, c);
Console.WriteLine($"MyString = {mapped.MyString}, MyInt = {mapped.MyInt}");
// prints: { MyString = "bar", MyInt = 100 };
