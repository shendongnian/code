    public class CustomDispatcher
    {
        private readonly BlockingCollection<(Action Action,
            TaskCompletionSource<bool> TCS)> _blockingCollection =
            new BlockingCollection<(Action, TaskCompletionSource<bool>)>();
        public void Run()
        {
            foreach (var item in _blockingCollection.GetConsumingEnumerable())
            {
                try
                {
                    item.Action.Invoke();
                    item.TCS.SetResult(true);
                }
                catch (Exception ex)
                {
                    item.TCS.TrySetException(ex);
                }
            }
        }
        public Task InvokeAsync(Action action)
        {
            var tcs = new TaskCompletionSource<bool>();
            _blockingCollection.Add((action, tcs));
            return tcs.Task;
        }
        public void Invoke(Action action) => InvokeAsync(action).Wait();
        public void InvokeShutdown() => _blockingCollection.CompleteAdding();
    }
