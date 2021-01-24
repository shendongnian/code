private static TimeSpan pollingInterval;
private static Task regenerationTask;
private static CancellationTokenSource quitThreadEvent;
private static ConcurrentQueue<KeyValuePair<string, string>> queue = new ConcurrentQueue<KeyValuePair<string, string>>();
internal static void Start()
{
    pollingInterval = TimeSpan.FromSeconds(100);
    quitThreadEvent = new CancellationTokenSource();
    regenerationTask = ExecuteAsync( quitThreadEvent.Token );
}
internal static async Task ExecuteAsync(CancellationToken cancellationToken)
{   
    queue.Enqueue(new KeyValuePair<string, string>("user1", "password1"));
    queue.Enqueue(new KeyValuePair<string, string>("user2", "password2"));
    queue.Enqueue(new KeyValuePair<string, string>("user3", "password3"));
    while ( true )
    {
        await Task.Delay( pollingInterval, cancellationToken ).ConfigureAwait( false );
        // tempList isn't empty, I checked it putting logs here.
        if (tempList.Length != 0)
        {
            var temp = new KeyValuePair<string, string>();
            if (queue.TryDequeue(out temp))
            {
                string username = temp.Key;
                string password = temp.Value;
                // fire and forget task - we do not want to await
                // so we do not need to store the task instance
                _ = WorkWithAsync(username, password);
            }
        }
        WriteToFile("End of Method");
    }
}
private static async Task WorkWithAsync( string username, string password )
{
    await tempfunc( username, password ).ConfigureAwait( false );
    queue.Enqueue(new KeyValuePair<string, string>(username, password));
}
If you miss the `Stop` method
internal static void Stop()
{
    quitThreadEvent.Cancel();
    regenerationTask.Wait();
}
internal static async Task StopAsync()
{
    quitThreadEvent.Cancel();
    await regenerationTask;
}
