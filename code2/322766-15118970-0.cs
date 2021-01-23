    public void DoSomeOperationAsync() {
        var context = SynchronizationContext.Current;
        Task.Factory
            .StartNew(() => Thread.Sleep(1000) /* simulate a long operation */)
            .ContinueWith(t => {
                context.Post(_ => OnSomeOperationCompleted(), null);
            });
    }
