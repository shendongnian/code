    var options=new ExecutionDataflowBlockOptions { 
                        MaxDegreeOfParallelism = 4 ,
                        BoundedCapacity=10,
                };
    var spamBlock=new TransformManyBlock<Line,Result>(
                                   y=>GetTasks(y.LineCode),
                                   options);
    var outputBlock=new BufferBlock<Result>();
    spamBlock.LinkTo(outputBlock);
    foreach(var line in lines)
    {
        await spamBlock.SendAsync(line);
    }
    spamBlock.Complete();
    //Wait for all 4 workers to finish
    await spamBlock.Completion;
