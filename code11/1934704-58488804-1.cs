    class DataMessage
    {
        public string Connection{get;set;}
        public DataTable Data {get;set;} 
    }
   ...
    var options=new ExecutionDataflowBlockOptions { 
                        MaxDegreeOfParallelism = 50,
                        BoundedCapacity = 8
                };
    var block=new ActionBlock<DataMessage>(msg=>MyBulkCopyMethod(msg.Connection,msg.Data, options);
