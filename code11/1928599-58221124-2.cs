private static async IAsyncEnumerable<(string Url, bool IsValid)> ValidateUrls(
    this IAsyncEnumerable<string> urls)
{
    await foreach (var url in urls)
    {
        Console.WriteLine($"Url {url} received");
        var isValid=await MockValidateUrl(url);
        yield return (url, isValid);
    }
}
There's no need for a worker Task as all methods are asynchronous. The iterator method won't proceed unless a consumer *asks* for a result. Even if `MockValidateUrl` does something expensive, it could use a `Task.Run` itself or get wrapped in a `Task.Run`. That would generate quite a few tasks though.
For completeness' sake you can add a `CancellationToken` and `ConfigureAwait(false)` :
    public static async IAsyncEnumerable<(string Url, bool IsValid)> ValidateUrls(
           IAsyncEnumerable<string> urls, 
           [EnumeratorCancellation]CancellationToken token=default)
    {
        await foreach(var url in urls.WithCancellation(token).ConfigureAwait(false))
        {
            var isValid=await MockValidateUrl(url).ConfigureAwait(false);
            yield return (url,isValid);
        }
    }
In any case, as soon as the caller stops iterating, `ValidateUrls` will stop.
**Buffering**
Buffering is a problem - no matter how it's programmed, the worker won't stop until the buffer fills. The buffer's size is how many iterations the worker will go on before it realizes it needs to stop. This is a great case for a Channel (yes, again!) :
    public static IAsyncEnumerable<(string Url, bool IsValid)> ValidateUrls(
            IAsyncEnumerable<string> urls,CancellationToken token=default)
    {
        var channel=Channel.CreateBounded<(string Url, bool IsValid)>(2);
        var writer=channel.Writer;
        _ = Task.Run(async ()=>{
                    await foreach(var url in urls.WithCancellation(token))
                    {
                        var isValid=await MockValidateUrl(url);
                        await writer.WriteAsync((url,isValid));
                    }
            },token)
            .ContinueWith(t=>writer.Complete(t.Exception));        
        return channel.Reader.ReadAllAsync(token);
    }
It's better to pass around ChannelReaders instead of IAsyncEnumerables though. At the very least, no async enumerator is constructed until someone tries to read from the ChannelReader. It's also easier to construct pipelines as extension methods :
    public static ChannelReader<(string Url, bool IsValid)> ValidateUrls(
            this ChannelReader<string> urls,int capacity,CancellationToken token=default)
    {
        var channel=Channel.CreateBounded<(string Url, bool IsValid)>(capacity);
        var writer=channel.Writer;
        _ = Task.Run(async ()=>{
                    await foreach(var url in urls.ReadAllAsync(token))
                    {
                        var isValid=await MockValidateUrl(url);
                        await writer.WriteAsync((url,isValid));
                    }
            },token)
            .ContinueWith(t=>writer.Complete(t.Exception));        
        return channel.Reader;
    }
This syntax allows constructing pipelines in a fluent manner. Let's say we have this helper method to convert IEnumerables to channesl (or IAsyncEnumerables) :
    public static ChannelReader<T> AsChannel(
             IEnumerable<T> items)
    {
        var channel=Channel.CreateUnbounded();        
        var writer=channel.Writer;
        foreach(var item in items)
        {
            channel.TryWrite(item);
        }
        return channel.Reader;
    }
We can write :
    var pipeline=urlList.AsChannel()     //takes a list and writes it to a channel
                        .ValidateUrls();
    await foreach(var (url,isValid) in pipeline.ReadAllAsync())
    {
       //Use the items here
    }
                  
**Concurrent calls with immediate propagation**
That's easy with channels, although the worker in this time needs to fire all of the tasks at once. Essentially, we need multiple workers. That's not something that can be done with just IAsyncEnumerable.
First of all, if we wanted to use eg 5 concurrent tasks to process the inputs we could write 
        var tasks = Enumerable.Range(0,5).
                      .Select(_ => Task.Run(async ()=>{
                                     /// 
                                 },token));
        _ = Task.WhenAll(tasks)(t=>writer.Complete(t.Exception));        
instead of :
        _ = Task.Run(async ()=>{
            /// 
            },token)
            .ContinueWith(t=>writer.Complete(t.Exception));        
Using a large number of workers could be enough. I'm not sure if IAsyncEnumerable can be consumed by multiple workers, and I don't really want to find out.
**Premature Cancellation**
All of the above work if the client consumes all results. To stop processing after eg the first 5 results though, we need the CancellationToken :
    var cts=new CancellationTokenSource();
    var pipeline=urlList.AsChannel()     //takes a list and writes it to a channel
                        .ValidateUrls(cts.Token);
    int i=0;
    await foreach(var (url,isValid) in pipeline.ReadAllAsync())
    {
        //Break after 3 iterations
        if(i++>2)
        {
            break;
        }
        ....
    }
    cts.Cancel();
This code itself could be extracted in a method that receives a ChannelReader and, in this case, the CancellationTokenSource :
static async LastStep(this ChannelReader<(string Url, bool IsValid)> input,CancellationTokenSource cts)
    {
    int i=0;
    await foreach(var (url,isValid) in pipeline.ReadAllAsync())
    {
        //Break after 3 iterations
        if(i++>2)
        {
            break;
        }
        ....
    }
    cts.Cancel();        
}
And the pipeline becomes :
    var cts=new CancellationTokenSource();
    var pipeline=urlList.AsChannel()     
                        .ValidateUrls(cts.Token)
                        .LastStep(cts);
