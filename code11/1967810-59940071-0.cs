var a = new TestA();
a.Prop.Id = 1;
	
Method(a, "Prop");
	
Console.Write(a.Prop);
public bool Method(object obj, string propName)
{
    // if condition is met
	obj.GetType().GetProperty(propName).SetValue(obj, null);
	return false;
}
public class TestA
{
	public TestB Prop { get; set; } = new TestB();
}
public class TestB
{
	public int Id { get; set; }
}
In the above example, `a.Prop` will be null.
