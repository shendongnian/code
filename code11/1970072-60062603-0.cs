    var channels = new Dictionary<string, ActionBlock<ConsumeResult<string, string>>>();
    foreach (var topic in _consumer.Subscription)
    {
    	channels.Add(topic, new ActionBlock<ConsumeResult<string, string>>(async consumeResult =>
    	{
    		... processing here
    		_consumer.Commit(consumeResult);
    	}, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 1 }));
    }
