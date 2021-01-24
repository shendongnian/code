    public class CompositeAsyncProcessor<T>
    {
        //...
        public Task Process(T input)
        {
            Task current = Task.CompletedTask;
            foreach (AsyncProcessor<T> processor in m_processors)
            {
                current = current.ContinueWith(antecessor =>
                {
                    if (antecessor.IsFaulted)
                        return Task.FromException<T>(antecessor.Exception.InnerException);
                    return processor.Process(input);
                },
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default
                ).Unwrap();
            }
            return current;
        }
    }
