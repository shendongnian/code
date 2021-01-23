    public class AsyncQueue<T> : IAsyncEnumerable<T>
    {
        private readonly SemaphoreSlim _enumerationSemaphore = new SemaphoreSlim(1);
        private readonly BufferBlock<T> _bufferBlock = new BufferBlock<T>();
        public void Enqueue(T item) =>
            _bufferBlock.Post(item);
        public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken token = default)
        {
            // We lock this so we only ever enumerate once at a time.
            // That way we ensure all items are returned when iterating over
            // the queue in an await foreach.
            await _enumerationSemaphore.WaitAsync();
            try {
                // Return new elements until cancellationToken is triggered.
                while (!token.IsCancellationRequested) {
                    yield return await _bufferBlock.ReceiveAsync(token);
                }
            } finally {
                _enumerationSemaphore.Release();
            }
        }
    }
