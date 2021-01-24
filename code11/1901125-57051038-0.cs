public abstract class MyBase
{
	private MyBase()
	{
	}
	public MyBase(string a)
	{
	}
}
public class MyDerived : MyBase
{
	public MyDerived(string a) : base(a)
	{
	}
}
You can even delete the private constructor if its not needed  
