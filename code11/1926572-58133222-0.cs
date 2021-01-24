    internal class ShardedSendStrategy
    {
      const int QueueCount = 8;
      readonly BlockingCollection<Action>[] Queues 
        = new BlockingCollection<Action>[QueueCount];
      readonly CancellationToken CancellationToken;
  
      public ShardedSendStrategy(CancellationToken cancellationToken)
      {
        CancellationToken = cancellationToken;
    
        for (int i = 0; i < QueueCount; i++)
        {
		  var id = i;
          Queues[id] = new BlockingCollection<Action>();
          var thread = new Thread( () => OnHandlerStart(Queues[id])) 
                                 { IsBackground = true };
          thread.Start();
        }
      }
      public Task<TResponse> Send<TResponse>(
        Func<IRequest<TResponse>, CancellationToken, Task<TResponse>> func, 
        IRequest<TResponse> request, CancellationToken cancellationToken = default)
      {
        var shard = request.GetHashCode() % QueueCount;
        var tcs = new TaskCompletionSource<TResponse>();
    		
    	Queues[shard].Add(() => {
          var result = func(request, cancellationToken).Result;
          tcs.SetResult(result);
        });
    
        return tcs.Task;
      }
    
      private void OnHandlerStart(BlockingCollection<Action> queue)
      {
        foreach (var job in queue.GetConsumingEnumerable(CancellationToken))
        {
          job();
        }
      }
    }
