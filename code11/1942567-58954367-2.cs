private ChannelReader<MyType2> Step1(ChannelReader<MyType> reader,CancellationToken token=default)
{
    var channel=Channel.CreateUnbounded<MyOtherType>();
    var writer=channel.Writer;
    _ = Task.Run(async ()=>{
        await foreach(var item from reader.ReadAllAsync(token))
        {
             MyType2 result=........;
             await writer.WriteAsync(result);
        }
    },token).ContinueWith(t=>channel.TryComplete(t));
    return channel.Reader;    
}
Some things to note :
- You can create multiple tasks if you want and use `Task.WhenAll` to await for all workers to complete before closing the channel.
- You can use a *bounded* channel to prevent a lot of messages accumulating if the pipeline isn't fast enough. 
- If the cancellation gets signalled, both reading from the input channel *and* the worker task will get cancelled. 
- When the worker task completes, whether because it was cancelled or threw, the channel will be closed.
- When the "head" channel completes, completion will flow from one step to the next.
**Combining steps**
Multiple steps can be combined by passing one's output reader to another's input reader, eg :
    var cts=new CancelaltionTokenSource();
 
    var step1=Step1(headReader,cts.Token);
    var step2=Step2(step1,cts.Token);
    var step3=Step3(step2,cts.Token);
    ...
    await stepN.Completion;
The CancellationTokenSource can be used to end the pipeline prematurely or set a timeout as a safeguard against hanged pipelines. 
**The pipeline head**
The "head" reader could come from an "adapter" method like : 
private ChannelReader<T> ToChannel(IEnumerable<T> input,CancellationToken token)
{
    var channel=Channel.CreateUnbounded<T>();
    var writer=channel.Writer;
    foreach(var item from input)
    {
        if (token.IsCancellationRequested)
        {
            break;
        }
        writer.TryWrite(result);
    }
    //No-one else is going to complete this channel
    channel.Complete();
    return channel.Reader;    
}
In the case of a background service, we could use a service method to "post" input to a head channel, eg :
class MyService
{
    Channel<MyType0> _headChannel;
    public MyService()
    {
        _headChannel=Channel.CreateBounded<MyType0>(5);
    }
    public async Task ExecuteAsync(CancellationToken token)
    {
        var step1=Step1(_headChannel.Reader,token);
        var step2=Step2(step1,token);        
        await step2.Completion;
    }
    public Task PostAsync(MyType0 input)
    {
        return _headChannel.Writer.WriteAsync(input);
    }
    public Stop()
    {
        _headChannel.Writer.TryComplete();
    }
...
}
I'm using method names that look like the [BackgroundService method names](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.2&tabs=visual-studio#queued-background-tasks-1) on purpose. StartAsync or ExecuteAsync can be used to set up the pipeline. StopAsync can be used to signal its completion, eg when the end user hits <kbd>Ctrl</kbd>+<kbd>C</kbd>. 
Another useful technique shown in the [queued BackgroundService](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.2&tabs=visual-studio#queued-background-tasks-1) example is registering an interface that clients can use to post messages instead of accessing the service class directly, eg :
interface IQueuedService<T>
{
    Task PostAsync(T input);
}
**Combined with System.Linq.Async**
The `ReadAllAsync()` method returns an `IAsyncEnumerable<T>` which means we can use operators in [System.Linq.Async](https://www.nuget.org/packages/System.Linq.Async) like Where or Take to filter, batch or transform messages eg :
private ChannelReader<MyType> ActiveOnly(ChannelReader<MyType> reader,CancellationToken token=default)
{
    var channel=Channel.CreateUnbounded<MyType>();
    var writer=channel.Writer;
    _ = Task.Run(async ()=>{
        var inpStream=reader.ReadAllAsync(token)
                            .Where(it=>it.IsActive);
        await foreach(var item from inpStream)
        {
             await writer.WriteAsync(item);
        }
    },token).ContinueWith(t=>channel.TryComplete(t));
    return channel.Reader;    
}
