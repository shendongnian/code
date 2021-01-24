    ChannelReader<string> Downloader(ChannelReader<string> ulrs,HttpClient client,
                                     int capacity,int dop,CancellationToken token=default)
    {
        var channel=Channel.CreateBounded(capacity);
        var writer=channel.Writer;
        
        var tasks  = Enumerable
                       .Range(0,dop)
                       .Select(_=> Task.Run(async ()=>{
                           await foreach(var url in urls.ReadAllAsync(token))
                           {
                               var response=await client.GetStringAsync(url);
                               await writer.WriteAsync(response);
                           }
                        });
        _=Task.WhenAll(tasks)
              .ContinueWith(t=>writer.Complete(t.Exception));
        return channel.Reader;
    }
