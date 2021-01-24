csharp
public static class AsyncHelper  
{
    private static readonly TaskFactory _taskFactory = new
        TaskFactory(CancellationToken.None,
                    TaskCreationOptions.None,
                    TaskContinuationOptions.None,
                    TaskScheduler.Default);
    public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        => _taskFactory
            .StartNew(func)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
    public static void RunSync(Func<Task> func)
        => _taskFactory
            .StartNew(func)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
}
Allowing you to do that : 
csharp
static async Task RunAsync(Task endpoint) {
   AsyncHelper.RunSync(() => endpoint());  
}
PS. have a look here [Ms AsyncHelper][1] and here [C# Async Tips & Tricks][2]
  [1]: https://github.com/aspnet/AspNetIdentity/blob/master/src/Microsoft.AspNet.Identity.Core/AsyncHelper.cs
  [2]: https://cpratt.co/async-tips-tricks/
