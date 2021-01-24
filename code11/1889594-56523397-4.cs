    foreach(var client in clients)
    {
        await batchClients.SendAsync(client);
    }
    //Tell the *batch block* we're done
    batchClient.Complete();
    //Await for all queued messages to finish processing
    await block.Completion;
    
