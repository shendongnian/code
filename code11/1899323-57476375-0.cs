    public static class DataflowExtensions
    {
        public static void OnFaultedCancel(this IDataflowBlock dataflowBlock,
            CancellationTokenSource cts)
        {
            dataflowBlock.Completion.ContinueWith(_ => cts.Cancel(), default,
                TaskContinuationOptions.OnlyOnFaulted |
                TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }
    }
