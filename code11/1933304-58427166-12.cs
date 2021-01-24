    ChannelReader<string> Downloader(ChannelReader<string> ulrs,HttpClient client,
                                     int capacity,CancellationToken token=default)
    {
        var channel=Channel.CreateBounded(capacity);
        var writer=channel.Writer;
        
        _ = Task.Run(async ()=>{
            await foreach(var url in urls.ReadAsStreamAsync(token))
            {
                var response=await client.GetStringAsync(url);
                await writer.WriteAsync(response);
            }
        }).ContinueWith(t=>writer.Complete(t.Exception));
        return channel.Reader;
    }
