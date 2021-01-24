cs
public Task StartAsync(CancellationToken c)
{
    var cs = new TaskCompletionSource<bool>();
    
    c.Register(() => { Abort(); cs.SetCanceled(); } );
    Start(() => { cs.SetResult(true); });
    return cs.Task;
}
cs
using (var ct = new CancellationTokenSource(1000))
{
    try
    {
        await StartAsync(ct.Token);
        MessageBox.Show("Completed");
    }
    catch (TaskCanceledException)
    {
        MessageBox.Show("Cancelled");
    }
}
<s>There is no point to use the cancellation token because the only points where it can fire is immediately after the method is called and immediately before it's finished, at which point it's a race condition.</s>
