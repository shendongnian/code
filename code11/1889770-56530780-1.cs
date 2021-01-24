C#
public class Program
{
	public static void Main()
	{
		object datas = new ClassList<string>() { "github", "microsoft" };
		var result = SomeClass.SomeMethod(datas);//Error :  CS0411 The type arguments for method 'UserQuery.SomeClass.SomeMethod<T>(UserQuery.ClassList<T>)' cannot be inferred from the usage. Try specifying the type arguments explicitly.
	}
}
public class ClassList<T> : List<T>
{
	public int SomeProperty { get; set; }
}
public class SomeClass
{
	public static ClassList<T> SomeMethod<T>(ClassList<T> value)
	{
		ClassList<T> otherList = (ClassList<T>)value;
		return otherList;
	}
}
