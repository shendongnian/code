    ChannelReader<int> MyProducer(someparameters,CancellationToken token)
    {
        var channel=Channel.CreateUnbounded<int>();
        var writer=channel.Writer;
        _ = Task.Run(async()=>{
                while(!token.IsCancellationRequested)
                {
                    var i= ... //do something to produce a value
                    await writer.WriteAsync(i,token);
                }
            },token)
            //IMPORTANT: Close the channel no matter what.
            .ContinueWith(t=>writer.Complete(t.Exception));                
        return channel.Reader;
    }
