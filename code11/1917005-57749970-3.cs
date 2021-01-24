    var stopWatch = Stopwatch.StartNew();
    var query = context.Messages.Select(x => x.MessageId).Max();
    stopWatch.Stop();
    Console.WriteLine(stopWatch.ElapsedMilliseconds + "ms. (Select.Max)" + "  " + query);
    stopWatch.Restart();
    
    query = context.Messages.Select(x => x.MessageId).Max(x=>x);
    stopWatch.Stop();
    Console.WriteLine(stopWatch.ElapsedMilliseconds + "ms. (Select.Max(x=>))" + "  " + query);
    stopWatch.Restart();
    
    query = context.Messages.Max(x => x.MessageId);
    stopWatch.Stop();
    Console.WriteLine(stopWatch.ElapsedMilliseconds + "ms. (Max(x=>))" + "  " + query);
    stopWatch.Restart();
    
    var result = context.Messages.Where(x => x.MessageId == context.Messages.Max(y => y.MessageId)).Single();
    stopWatch.Stop();
    Console.WriteLine(stopWatch.ElapsedMilliseconds + "ms. (get by Max(x=>))"  + "  " + result.MessageId);
