cs
public void RunHelloIfPossible(object anyObject)
{
	switch (anyObject)
	{
		case classZero zero:
			zero.Hello();
			break;
		case classOne one:
			one.Hello();
			break;
	}			
}
Example of the usage
cs
RunHelloIfPossible(new classOne());
If both classes implement the same interface (lets say `IHello`) or base class, the code above can be simplified to
cs
if (anyObject is IHello hello)
{
	hello.Hello();
}
