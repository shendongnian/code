private async Task  ExecuteSequential()
{
    var sequentialMethods = new List<Func<Task>>()
    {
        () => Task.Run(SomeMethod1),
        () => Task.Run(() => SomeMethod2("Hey!")), 
        ExecuteParallelAsync, 
        () => Task.Run(SomeMethod3),
        () => Task.Run(SomeMethod4)
    };
    for ( int i = 0 ; i < sequentialMethods.Count ; i++ )
    {
        Task t = sequentialMethods[i].Invoke(); 
		await t;
        // or just await sequentialMethods[i]();
    }
}
----
Just for the record, `ExecuteSequential` could just be a standard async method (which are very good in executing things sequentially). 
private async Task ExecuteSequential()
{
  SomeMethod1();
  SomeMethod2();
  await ExecuteParallelAsync(); 
  SomeMethod3();
  SomeMethod4();
};
----
# Edit: Test 
##Code 
class Program
{
    public void MyMethod1() => Console.WriteLine("||My1");
    public void MyMethod2() => Console.WriteLine("||My2");
    public void MyMethod3() => Console.WriteLine("||My3");
    private async Task ExecuteParallelAsync()
    {
        Console.WriteLine("||Start");
        List<Action> methods = new List<Action>() { MyMethod1, MyMethod2, MyMethod3 };
        await Task.Run(() => { Parallel.ForEach(methods, 
           (currentMethod) => currentMethod.Invoke()); }); // This could be just 'currentMethod();' (no Invoke())
        Console.WriteLine("||End");
    }
    public void SomeMethod1() => Console.WriteLine("Some1");
    public void SomeMethod2(string s) => Console.WriteLine($"Some2: {s}");
    public void SomeMethod3() => Console.WriteLine("Some3");
    public void SomeMethod4() => Console.WriteLine("Some4");
    private async Task ExecuteSequential()
    {
        var sequentialMethods = new List<Func<Task>>()
        {
           () => Task.Run(SomeMethod1),
           () => Task.Run(() => SomeMethod2("Hey!")),
           ExecuteParallelAsync,
           () => Task.Run(SomeMethod3),
           () => Task.Run(SomeMethod4)
        };
        for (int i = 0; i < sequentialMethods.Count; i++)
        {
            await sequentialMethods[i]();
        }
    }
    static async Task Main(string[] args)
    {
        await new Program().ExecuteSequential();
        Console.WriteLine("All done");
    }
}
## Output
Some1
Some2: Hey!
||Start
||My3
||My2
||My1
||End
Some3
Some4
All done
`My1`, `My2`, and `My3` will change order between executions, but always within `||Start` and `||End`.
