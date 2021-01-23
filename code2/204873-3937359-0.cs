    var tasks = new List<Task>();
    
    var wsResult = 0;
    string dbResult = null;
    var cacheResult = "";
    tasks.Add( new Task( ()=> wsResult = CallWebService()));
    tasks.Add( new Task( ()=> dbResult = QueryDB()));
    tasks.Add( new Task( ()=> cacheResult = QueryLocalCache()));
    tasks.ForEach( t=> t.Start());
    Task.WaitAll( tasks.ToArray());
    
    Console.WriteLine(string.Format(dbResult, wsResult, cacheResult));
