    ChannelReader<Customer> Producer(IEnumerable<Customer> customers,CancellationToken token=default)
    {
        //Create a channel that can buffer an infinite number of entries
        var channel=Channel.CreateUnbounded();
        var writer=channel.Writer;
        //Start a background task to produce the data
        _ = Task.Run(async ()=>{
            foreach(var customer in customers)
            {
                //Exit gracefully in case of cancellation
                if (token.IsCancellationRequested)
                {
                    return;
                }
                await writer.WriteAsync(customer,token);
                await Task.Delay(500);
            }
        },token)
             //Ensure we complete the writer no matter what
             .ContinueWith(t=>writer.Complete(t.Exception);
       return channel.Reader;
    }
