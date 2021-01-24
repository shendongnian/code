lang-c#
public interface ISomething
{
	void Say();
}
public abstract class BaseClass : ISomething
{
	public void Say(string something)
	{
		Console.WriteLine("Say: " + something);
	}
}
public class DerivedClass : BaseClass
{
}
var x = new DerivedClass() as ISomething;
x.Say("Derived");
