c#
[Test]
public void TerminateOtherWhenOneCompleted()
{
    var canceller = new CancellationTokenSource();
    
    int t1WaitDurationInSeconds = 3;
    int t2WaitDurationInSeconds = 1;
    var taskOne = Task.Run(() =>
    {
        try
        {
            // do the thing
            Console.WriteLine("T1 working ...");
            // wait a bit ...
            await Task.Delay(TimeSpan.FromSeconds(t1WaitDurationInSeconds), canceller.Token);
            // checking for cancellation
            canceller.Token.ThrowIfCancellationRequested();
            // do more things ...
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("T1 was aborted");
        }
    }, canceller.Token);
    var taskTwo = Task.Run(() =>
    {
        try
        {
            // do the thing
            Console.WriteLine("T2 working ...");
            // wait a bit ...
            await Task.Delay(TimeSpan.FromSeconds(t2WaitDurationInSeconds), canceller.Token);
            // checking for cancellation
            canceller.Token.ThrowIfCancellationRequested();
            // do more things ...
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("T2 was aborted");
        }
    }, canceller.Token);
    var completedIndex = Task.WaitAny(taskOne, taskTwo);
    Console.WriteLine($"T{completedIndex+1} completed." );
    canceller.Cancel();
    Task.Delay(TimeSpan.FromSeconds(2)).Wait();
}
And output will be 
>T1 working ... T2 working ... T2 completed. T1 was aborted
You can change the wait duration to test that having T1 completed first will also work.
Hopes this helps.
  
  [1]: https://stackoverflow.com/a/4359927/734181
  [2]: http://msdn.microsoft.com/en-us/library/ty8d3wta.aspx
