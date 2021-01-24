public async Task StartAll(CancellationToken ct)
{
    ct.ThrowIfCancellationRequested();
    await TurnOnPump1();
    await Task.Delay(TimeSpan.FromSeconds(15), ct);
    ct.ThrowIfCancellationRequested();
    await TurnOnPump2();
    await Task.Delay(TimeSpan.FromMinutes(10), ct);
    ct.ThrowIfCancellationRequested();
    await TurnOnPump3();
    //And so on..
}
public asnyc Task StopAll()
{
    // Your_CancellationTokenSource should be defined somewhere else
    Your_CancellationTokenSource.Cancel(); 
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
    catch (OperationCanceledException)
    {
        // Starting was cancelled
    }
}
This way, `StopAll` can be called anytime during the starting and you don't get any issues.  
Note: `Your_CancellationTokenSource` should of course be some variable outside of these methods so it can be shared.
