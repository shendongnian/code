    public class JobQueue<T>
    {
        private readonly ConcurrentQueue<T> _jobs = new ConcurrentQueue<T>();
        private readonly SemaphoreSlim _signal = new SemaphoreSlim(0);
        public void Enqueue(T job)
        {
            _jobs.Enqueue(job);
            _signal.Release();
        }
        public async Task<T> DequeueAsync(CancellationToken cancellationToken = default)
        {
            await _signal.WaitAsync(cancellationToken);
            _jobs.TryDequeue(out var job);
            return job;
        }
    }
