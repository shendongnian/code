    public interface ICachedEnumerable<T> : IEnumerable<T>
    {
    }
    internal class CachedEnumerable<T> : ICachedEnumerable<T>
    {
        private readonly List<T> cache = new List<T>();
        private readonly IEnumerator<T> source;
        private bool sourceIsExhausted = false;
        public CachedEnumerable(IEnumerable<T> source)
        {
            this.source = source.GetEnumerator();
        }
        public T Get(int where)
        {
            if (where < 0)
                throw new InvalidOperationException();
            SyncUntil(where);
            return cache[where];
        }
        private void SyncUntil(int where)
        {
            lock (cache)
            {
                while (where >= cache.Count && !sourceIsExhausted)
                {
                    sourceIsExhausted = source.MoveNext();
                    cache.Add(source.Current);
                }
                if (where >= cache.Count)
                    throw new InvalidOperationException();
            }
        }
        public bool GoesBeyond(int where)
        {
            try
            {
                SyncUntil(where);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new CachedEnumerator<T>(this);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new CachedEnumerator<T>(this);
        }
        private class CachedEnumerator<T> : IEnumerator<T>, System.Collections.IEnumerator
        {
            private readonly CachedEnumerable<T> parent;
            private int where;
            public CachedEnumerator(CachedEnumerable<T> parent)
            {
                this.parent = parent;
                Reset();
            }
            public object Current
            {
                get { return Get(); }
            }
            public bool MoveNext()
            {
                if (parent.GoesBeyond(where))
                {
                    where++;
                    return true;
                }
                return false;
            }
            public void Reset()
            {
                where = -1;
            }
            T IEnumerator<T>.Current
            {
                get { return Get(); }
            }
            private T Get()
            {
                return parent.Get(where);
            }
            public void Dispose()
            {
            }
        }
    }
    public static class CachedEnumerableExtensions
    {
        public static ICachedEnumerable<T> AsCachedEnumerable<T>(this IEnumerable<T> source)
        {
            return new CachedEnumerable<T>(source);
        }
    }
