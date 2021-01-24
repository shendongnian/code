private async Task WriteItemsAsync(
    ChannelWriter<int> writer,
    int count,
    int delay,
    CancellationToken cancellationToken)
{
    try
    {
        for (var i = 0; i < count; i++)
        {
            // Check the cancellation token regularly so that the server will stop
            // producing items if the client disconnects.
            cancellationToken.ThrowIfCancellationRequested();
            await writer.WriteAsync(i);
            // Use the cancellationToken in other APIs that accept cancellation
            // tokens so the cancellation can flow down to them.
            await Task.Delay(delay, cancellationToken);
        }
        writer.TryComplete();
    }
    catch (Exception ex)
    {
        writer.TryComplete(ex);
    }   
}
This way, it's only called once, either when the loop terminates succesfully or when an exception is thrown for any reason.
Instead of throwing on cancellation with `ThrowIfCancellationRequested` you could simply break out of the loop :
for (var i = 0; i < count; i++)
{
    if (cancellationToken.IsCancellationRequested)
    {
        break;
    }
    await writer.WriteAsync(i);
    await Task.Delay(delay, cancellationToken);
}
writer.TryComplete();
In case of bounded channels, `WriteAsync` should also receive the cancellation token, otherwise it may get stuck if the channel is full:
await writer.WriteAsync(i,cancellationToken);
