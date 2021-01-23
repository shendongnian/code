c#
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("*********************************************************************");
        Console.WriteLine("* Start canceled task, don't pass token to constructor");
        Console.WriteLine("*********************************************************************");
        StartCanceledTaskTest(false);
        Console.WriteLine();
        Console.WriteLine("*********************************************************************");
        Console.WriteLine("* Start canceled task, pass token to constructor");
        Console.WriteLine("*********************************************************************");
        StartCanceledTaskTest(true);
        Console.WriteLine();
        Console.WriteLine("*********************************************************************");
        Console.WriteLine("* Throw if cancellation requested, don't pass token to constructor");
        Console.WriteLine("*********************************************************************");
        ThrowIfCancellationRequestedTest(false);
        Console.WriteLine();
        Console.WriteLine("*********************************************************************");
        Console.WriteLine("* Throw if cancellation requested, pass token to constructor");
        Console.WriteLine("*********************************************************************");
        ThrowIfCancellationRequestedTest(true);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Test Done!!!");
        Console.ReadKey();
    }
    static void StartCanceledTaskTest(bool passTokenToConstructor)
    {
        Console.WriteLine("Creating task");
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        Task task = null;
        if (passTokenToConstructor)
        {
            task = new Task(() => TaskWork(tokenSource.Token, false), tokenSource.Token);
        }
        else
        {
            task = new Task(() => TaskWork(tokenSource.Token, false));
        }
        Console.WriteLine("Canceling task");
        tokenSource.Cancel();
        try
        {
            Console.WriteLine("Starting task");
            task.Start();
            task.Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: {0}", ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("InnerException: {0}", ex.InnerException.Message);
            }
        }
        Console.WriteLine("Task.Status: {0}", task.Status);
    }
    static void ThrowIfCancellationRequestedTest(bool passTokenToConstructor)
    {
        Console.WriteLine("Creating task");
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        Task task = null;
        if (passTokenToConstructor)
        {
            task = new Task(() => TaskWork(tokenSource.Token, true), tokenSource.Token);
        }
        else
        {
            task = new Task(() => TaskWork(tokenSource.Token, true));
        }
        try
        {
            Console.WriteLine("Starting task");
            task.Start();
            Thread.Sleep(100);
            Console.WriteLine("Canceling task");
            tokenSource.Cancel();
            task.Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: {0}", ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("InnerException: {0}", ex.InnerException.Message);
            }
        }
        Console.WriteLine("Task.Status: {0}", task.Status);
    }
    static void TaskWork(CancellationToken token, bool throwException)
    {
        int loopCount = 0;
        while (true)
        {
            loopCount++;
            Console.WriteLine("Task: loop count {0}", loopCount);
            token.WaitHandle.WaitOne(50);
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Task: cancellation requested");
                if (throwException)
                {
                    token.ThrowIfCancellationRequested();
                }
                break;
            }
        }
    }
}
Output:
lang-none
*********************************************************************
* Start canceled task, don't pass token to constructor
*********************************************************************
Creating task
Canceling task
Starting task
Task: loop count 1
Task: cancellation requested
Task.Status: RanToCompletion
*********************************************************************
* Start canceled task, pass token to constructor
*********************************************************************
Creating task
Canceling task
Starting task
Exception: Start may not be called on a task that has completed.
Task.Status: Canceled
*********************************************************************
* Throw if cancellation requested, don't pass token to constructor
*********************************************************************
Creating task
Starting task
Task: loop count 1
Task: loop count 2
Canceling task
Task: cancellation requested
Exception: One or more errors occurred.
InnerException: The operation was canceled.
Task.Status: Faulted
*********************************************************************
* Throw if cancellation requested, pass token to constructor
*********************************************************************
Creating task
Starting task
Task: loop count 1
Task: loop count 2
Canceling task
Task: cancellation requested
Exception: One or more errors occurred.
InnerException: A task was canceled.
Task.Status: Canceled
Test Done!!!
