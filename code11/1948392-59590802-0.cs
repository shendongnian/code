    internal class TestAsyncEnumerable<T> : List<T>, IAsyncEnumerable<T>
    {
       public TestAsyncEnumerable(IEnumerable<T> enumerable) : base(enumerable) { }
    
       public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default) => new TestAsyncEnumerator<T>(GetEnumerator());
    }
    
    internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
       private readonly IEnumerator<T> _inner;
    
       public TestAsyncEnumerator(IEnumerator<T> inner)
       {
          _inner = inner;
       }
    
       public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(_inner.MoveNext());
    
       public T Current => _inner.Current;
    
       public ValueTask DisposeAsync()
       {
          _inner.Dispose();
    
          return new ValueTask(Task.CompletedTask);
       }
    }
