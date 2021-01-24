    var options=new ExecutionDataflowBlockOptions
         {
            MaxDegreeOfParallelism = _maxclientsToBeProcessed,
            BoundedCapacity = _maxclientsToBeProcessed*3, //Just a guess
         });
    var block=new ActionBlock<Client>(client=>CreateAndRunDDL(client));
    //Post the client requests
    foreach(var client in clients)
    {
        await block.SendAsync(client);
    }
    //Tell the block we're done
    block.Complete();
    //Await for all queued messages to finish processing
    await block.Completion;
