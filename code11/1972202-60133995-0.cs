private static TimeSpan pollingInterval;
private static Task regenerationask;
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
                // Method comes till here but doesn't execute the statement below and directly reach to end WriteToFile method.
                await tempFunc(username, password).ConfigureAwait( false );
                queue.Enqueue(new KeyValuePair<string, string>(username, password));
            }
        }
        WriteToFile("End of Method");
    }
}
