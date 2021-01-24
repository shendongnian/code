    var channel=Channel.CreateUnbounded<string>();
    var dlReader=Downloader(channel.Reader,client,5,5);
    foreach(var url in someUrlList)
    {
        await channel.Writer.WriteAsync(url);
    }
    channel.Writer.Complete();
