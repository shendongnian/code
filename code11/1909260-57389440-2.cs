public async Task StartAll(CancellationToken ct)
{
    await TurnOnPump1(); // no ct here because these methods should take little to no time to execute (see comment)
    await Task.Delay(TimeSpan.FromSeconds(15), ct);
    await TurnOnPump2();
    await Task.Delay(TimeSpan.FromMinutes(10), ct);
    await TurnOnPump3();
    //And so on..
}
public asnyc Task StopAll()
{
    // Your_CancellationTokenSource should be defined somewhere else
    Your_CancellationTokenSource.Cancel(); // this line makes Task.Delay throw a TaskCanceledException
    await StopPump1();  
    await StopPump2();   
    await StopPump3();   
    // ..
}
public async Task HowToCallStart()
{
    try
    {
        // Your_CancellationTokenSource should be defined somewhere else
        await StartAll(Your_CancellationTokenSource.Token);
    }
    catch (TaskCanceledException)
    {
        // Starting was canceled
    }
}
This way, `StopAll` can be called anytime during the starting and you don't get any issues.  
Note: `Your_CancellationTokenSource` should of course be some variable outside of these methods so it can be shared.
