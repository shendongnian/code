C#
static void Main()
{
	var numberTask = GetNumberAsync( 0 );
	Console.WriteLine( numberTask.Status );
	Console.ReadLine();
}
private static async Task<Int32> GetNumberAsync( Int32 number )
{
	if ( number == 0 )
		throw new NotSupportedException();
	await Task.Delay( 1000 );
	return number;
}
Try it out and you will see that the output of the program will be `Faulted`. The method is always returning a result which is Task<Int32> which has captured the exception.
Why the capturing occurs? It occurs because of `async` modifier of the method. Under the covers the actual execution of the method uses `AsyncMethodBuilder` which captures the exception and sets it as a result of the task.
How can we change this?
C#
private static Task<Int32> GetNumberAsync( Int32 number )
{
	if ( number == 0 )
		throw new NotSupportedException();
    return GetNumberReallyAsync();
    async Task<Int32> GetNumberReallyAsync()
    {
	    await Task.Delay( 1000 );
	    return number;
    }
}
In this example you can see that the method doesn't have the `async` modifier and thus the exception is not captured as a faulted Task.
So for your example to work as you want, you need to remove async and await:
C#
public Lazy<Task<string>> AsyncLazyProperty { get; } = new Lazy<Task<string>>(() =>
{
    if (i == 0)
        throw new Exception("My exception");
    return Task.FromResult("Hello World");
}, LazyThreadSafetyMode.PublicationOnly);
