    File 1:
    public static Task DoStuff(string myQueueItem, ILogger log)
    {
        //tranforms here
           
    }
    File 2 - n:
    [FunctionName("ConsumerA")]
    public static void QueueTrigger(
        [QueueTrigger("myqueue-items")] string myQueueItem,
        ILogger log)
    {
        await DoStuff(myQueueItem, log);
           
    }
