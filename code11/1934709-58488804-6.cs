    var block=new ActionBlock<DataMessage>(async msg=> {
        try {
            await MyBulkCopyMethod(msg.Connection,msg.Data, options);
        }
        catch(SqlException exc) when (some retry condition)
        {
            //Post without awaiting
            retryBlock.Post(msg);
        });
