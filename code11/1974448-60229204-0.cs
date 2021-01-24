        var xEvents = new QueryableXEventData(csb.ConnectionString, sessionName, EventStreamSourceOptions.EventStream, EventStreamCacheOptions.DoNotCache);
        var cancellationTokenSource = new CancellationTokenSource();
        var reader = Task.Factory.StartNew((o) =>
                   {
                       foreach (var evt in xEvents)
                       {
                           foreach (PublishedEventField fld in evt.Fields)
                           {
                               string fieldName = fld.Name;
                               string fieldValue = fld.Value.ToString();
                               Console.WriteLine(fieldName + " " + fieldValue);
                           }
                       } 
                   }, TaskCreationOptions.LongRunning
                    , cancellationTokenSource.Token);
    
        Console.WriteLine("Hit any key to exit");
        Console.ReadKey();
        cancellationTokenSource.Cancel();
        xEvents.Dispose();
        s.Stop();
        reader.Wait();
