    public static void QueueFunction(
            [QueueTrigger("QueueName")] string message,
            CancellationToken cancellationToken)
    {
        if(cancellationToken.IsCancellationRequested) return;
        ...
    }
    
   
