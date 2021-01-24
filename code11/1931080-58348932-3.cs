c#
public class LongRunningTaskSource
{
    public Task LongRunning(int milliseconds)
    {
        return Task.Run(() =>
        {
            Console.WriteLine("Starting long running task");
            Thread.Sleep(3000);
            Console.WriteLine("Finished long running task");
        });
    }
    public Task LongRunningTaskWrapper(int milliseconds, CancellationToken token)
    {
        Task task = LongRunning(milliseconds);
        Task wrapperTask = Task.Run(() =>
        {
            while (true)
            {
                //Check for completion (you could, of course, do different things
                //depending on whether it is faulted or completed).
                if (!(task.Status == TaskStatus.Running))
                    break;
                //Check for cancellation.
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Aborting Task.");
                    token.ThrowIfCancellationRequested();
                }
            }
        }, token);
        return wrapperTask;
    }
}
Using the following code:
c#
static Main()
{
    LongRunningTaskSource longRunning = new LongRunningTaskSource();
    CancellationTokenSource cts = new CancellationTokenSource(1500);
    Task task = longRunning.LongRunningTaskWrapper(3000, cts.Token);
    //Sleep long enough to let things roll on their own.
    Thread.Sleep(5000);
    Console.WriteLine("Ended Main");
}
...produces the following output:
Starting long running task
Aborting Task.
Exception thrown: 'System.OperationCanceledException' in mscorlib.dll
Finished long running task
Ended Main
The wrapped Task obviously completes in its own good time. If you **don't have a problem with that**, which is often **not** the case, hopefully, this should fit your needs.
As a supplementary example, running the following code (letting the wrapped Task finish before time-out):
c#
static Main()
{
    LongRunningTaskSource longRunning = new LongRunningTaskSource();
    CancellationTokenSource cts = new CancellationTokenSource(3000);
    Task task = longRunning.LongRunningTaskWrapper(1500, cts.Token);
    //Sleep long enough to let things roll on their own.
    Thread.Sleep(5000);
    Console.WriteLine("Ended Main");
}
...produces the following output:
Starting long running task
Finished long running task
Ended Main
So the task started and finished before timeout and nothing had to be cancelled. Of course nothing is blocked while waiting. As you probably already know, of course, if you **know** what is being used behind the scenes in the long-running code, it would be good to clean up if necessary.
Hopefully, you can adapt this example to pass something like this to your ActionBlock.
Disclaimer & Notes
===
I am not familiar with the TPL Dataflow library, so this is just a workaround, of course. Also, if all you have is, for example, a synchronous method call that you do not have any influence on at all, then you will obviously need **two** tasks. One wrapper task to wrap the synchronous call and another one to wrap the wrapper task to include continuous status polling and cancellation checks.
