    public class Throttle
    {
        private readonly TimeSpan perPeriod = TimeSpan.FromSeconds(1);
        private readonly SemaphoreSlim actionSemaphore = new SemaphoreSlim(5, 5);
    
        public async Task Queue(Func<Task> action, CancellationToken cancel)
        {
            await actionSemaphore.WaitAsync(cancel);
            try
            {
                await action();
            }
            finally
            {
                await Task.Delay(perPeriod, cancel).ContinueWith(_ => actionSemaphore.Release(1), cancel);
            }
    
        }
    }
