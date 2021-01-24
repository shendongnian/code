cs
public class B : I
{
	void I.foo()
	{
		Bar();
	}
	protected virtual void Bar()
	{
		Console.WriteLine("in B foo");
	}
}
public class D : B
{
	protected override void Bar()
	{
		base.Bar();
		Console.WriteLine("in D foo");
	}
}
Output will be the following
in B foo 
in D foo
There is also more simple option without explicit interface implementation
cs
public class B : I
{
	public virtual void foo()
	{
		Console.WriteLine("in B foo");
	}
}
public class D : B
{
	public override void foo()
	{
		base.foo();
		Console.WriteLine("in D foo");
	}
}
