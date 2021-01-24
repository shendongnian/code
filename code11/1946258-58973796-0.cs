    var uiCts = new CancellationTokenSource();
    var globalMsgQueue = new BlockingCollection<string>();
    var backgroundUiTask = new Task(() =>
    {
        foreach (var item in globalMsgQueue.GetConsumingEnumerable(uiCts.Token))
        {
            ConsumeMsgQueueItem(item);
        }
    }, uiCts.Token);
