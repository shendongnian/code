public async Task<OperationResult> ProcessApiRequest(List<string> ids)
{
    var channel = Channel.CreateBounded<string>(new BoundedChannelOptions(100) {SingleWriter = true});
    foreach (var id in ids)
    {
        await channel.Writer.WriteAsync(id); // If the back pressure exceeds 100 ids, we asynchronously wait here
    }
    channel.Writer.Complete();
    for (var i = 0; i < 8; i++) // 8 concurrent readers
    {
        _ = Task.Run(async () =>
        {
            await foreach (var id in channel.Reader.ReadAllAsync())
            {
                await this.doStuff(id);
                await this.doAnotherStuff(id);
            }
        });
    }
    return OperationResult.Success();
}
