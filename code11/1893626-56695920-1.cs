    var synchronizationSource = Observerable.Timer(TimeSpan.FromSeconds(1),TimeSpan.FromSeconds(1))
         .Publish()
    using(synchronizationSource.Connect())
    {
           IObservable<Stat> CreateTimeFrame(int seconds)
           {
               var bufferTimeFrame = synchronizationSource
                             .Where(i => i % seconds == 0);
               return priceChangedObservable
                   .GroupBy(instrument => instrument.Symbol)
                   .SelectMany(q => q)            
                   .Buffer(bufferTimeFrame)
                   .Where(messages => messages.Any())
                   .ObserveOn(dispatcher)
                   .Select((sr) => DoCalc(sr, timeFrame))
           }
           CreateTimeFrame(60)
              .Subscribe((en) => { if (null != en) Console.WriteLine(en); });
           CreateTimeFrame(300)
              .Subscribe((en) => { if (null != en) Console.WriteLine(en); });
           Thread.Sleep(100000);
     }
