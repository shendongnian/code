c#
async Task Main()
{
    await PrintLoop(Print1); //not Print1()
}
async Task Print1()
{
    Debug.WriteLine("Printing!");
}
async Task PrintLoop(Func<Task> printer, int iterations = 3)
{
    for (int i = 0; i < iterations; i++)
    {
        await printer();
    }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.func-1
