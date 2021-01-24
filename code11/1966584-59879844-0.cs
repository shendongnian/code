    class Payload
    {
        public string SessionKey{get;set;}
        public string Key{get;set;}
        public string Name{get;set;}
        public string Value{get;set;}
        public int TTL{get;set;}
    }
    //Allow only 10 concurrent upserts
    var options=new ExecutionDataflowBlockOptions
      {
         MaxDegreeOfParallelism = 10
      };
    var upsertBlock=new ActionBlock<Payload>(myPosterAsync,options);
    foreach(var payload in payloads)
    {
        block.Post(pair);
    }
    //Tell the block we're done
    block.Complete();
    //Await for all queued operations to complete
    await block.Completion;
