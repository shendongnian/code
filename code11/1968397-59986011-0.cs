    var logSubject = new Subject<string>();
    var logMessagesChangedStream = logSubject.DistinctUntilChanged().Publish(); // log on every message change
    var logMessagesSampleStream = logSubject.Sample(TimeSpan.FromSeconds(5)); // log at least every 5 seconds    
    var oneof =
            Observable
              .Amb(logMessagesChangedStream, logMessagesSampleStream)
              .Take(1)
              .Repeat(); 
       logMessagesChangedStream.Connect();
       oneof.Timestamp().Subscribe(c => Console.WriteLine(c));
