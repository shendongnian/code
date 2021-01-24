    var retryOptions=new ExecutionDataflowBlockOptions { 
                    MaxDegreeOfParallelism = 5
            };
    var retryBlock=new ActionBlock<DataMessage>(async msg=>{
        await Task.Delay(1000);
        try {
            await MyBulkCopyMethod(msg.Connection,msg.Data, options);
        }
        catch (Exception ....)
        {
            ...
        }
    });
