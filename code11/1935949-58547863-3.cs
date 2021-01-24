    public class CachedAsyncEnumerable<T> : IAsyncEnumerable<T>
    {
        private readonly object _locker = new object();
        private IAsyncEnumerable<T> _source;
        private Task _sourceEnumerationTask;
        private List<T> _buffer;
        private TaskCompletionSource<bool> _moveNextTCS;
        private Exception _sourceEnumerationException;
        private int _sourceEnumerationVersion; // Incremented on exception
        public CachedAsyncEnumerable(IAsyncEnumerable<T> source)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }
        public async IAsyncEnumerator<T> GetAsyncEnumerator(
            CancellationToken cancellationToken = default)
        {
            lock (_locker)
            {
                if (_sourceEnumerationTask == null)
                {
                    _buffer = new List<T>();
                    _moveNextTCS = new TaskCompletionSource<bool>();
                    _sourceEnumerationTask = Task.Run(
                        () => EnumerateSourceAsync(cancellationToken));
                }
            }
            int index = 0;
            int localVersion = -1;
            while (true)
            {
                T current = default;
                Task<bool> moveNextTask = null;
                lock (_locker)
                {
                    if (localVersion == -1)
                    {
                        localVersion = _sourceEnumerationVersion;
                    }
                    else if (_sourceEnumerationVersion != localVersion)
                    {
                        ExceptionDispatchInfo.Capture(_sourceEnumerationException).Throw();
                    }
                    if (index < _buffer.Count)
                    {
                        current = _buffer[index];
                        index++;
                    }
                    else
                    {
                        moveNextTask = _moveNextTCS.Task;
                    }
                }
                if (moveNextTask == null)
                {
                    yield return current;
                    continue;
                }
                var moved = await moveNextTask;
                if (!moved) yield break;
                lock (_locker)
                {
                    current = _buffer[index];
                    index++;
                }
                yield return current;
            }
        }
        private async Task EnumerateSourceAsync(CancellationToken cancellationToken)
        {
            TaskCompletionSource<bool> localMoveNextTCS;
            try
            {
                await foreach (var item in _source.WithCancellation(cancellationToken))
                {
                    lock (_locker)
                    {
                        _buffer.Add(item);
                        localMoveNextTCS = _moveNextTCS;
                        _moveNextTCS = new TaskCompletionSource<bool>();
                    }
                    localMoveNextTCS.SetResult(true);
                }
                lock (_locker)
                {
                    localMoveNextTCS = _moveNextTCS;
                    _buffer.TrimExcess();
                    _source = null;
                }
                localMoveNextTCS.SetResult(false);
            }
            catch (Exception ex)
            {
                lock (_locker)
                {
                    localMoveNextTCS = _moveNextTCS;
                    _sourceEnumerationException = ex;
                    _sourceEnumerationVersion++;
                    _sourceEnumerationTask = null;
                }
                localMoveNextTCS.SetException(ex);
            }
        }
    }
