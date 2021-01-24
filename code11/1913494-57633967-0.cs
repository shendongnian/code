    private void ProcessAllResultPages<TResult, TItem>(IBaseRequest request,
                                                       Action<TResult> processorDelegate)
                                                       where TResult : ICollectionPage<TItem>
    {
        do
        {
            Task<TResult> task = ((dynamic)request).GetAsync();
            processorDelegate(task.Result); // This will implicitly call Wait() on the task.
            request = ((dynamic)task.Result).NextPageRequest;
        } while (request != null);
    }
