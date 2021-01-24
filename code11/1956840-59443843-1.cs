    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public static class AsyncEnumerable
    {
        public static IAsyncEnumerator<T> Empty<T>() => EmptyAsyncEnumerator<T>.Instance;
        class EmptyAsyncEnumerator<T> : IAsyncEnumerator<T>
        {
            public static readonly EmptyAsyncEnumerator<T> Instance = 
                new EmptyAsyncEnumerator<T>();
            public T Current => default!;
            public ValueTask DisposeAsync() => default;
            public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(false);
        }
    }
