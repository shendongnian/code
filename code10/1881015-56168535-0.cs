private static async Task CreateTask2(CancellationToken token)
{
    try
    {
        // Pass on the token when calling other functions.
        await Task.Delay(8000, token);
        // And manually check during long operations.
        for (int i = 0; i < 10000; i++)
        {
            // Do we need to cancel?
            token.ThrowIfCancellationRequested();
                 
            // Simulating work.
            Thread.SpinWait(5000);
        }
        Console.WriteLine("This is task two");
    }
    catch (Exception e)
    {
        Console.WriteLine("Task 2 was cancelled by Task 1");
        Console.WriteLine(e);
    }
}
