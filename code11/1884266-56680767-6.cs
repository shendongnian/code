    static class DisposableHelper
    {
        public static IEnumerable<TResult> ToDisposable<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector) where TResult : IDisposable
        {
            var exceptions = new List<Exception>();
            var result = new List<TResult>();
            foreach (var i in source)
            {
                try { result.Add(selector(i)); }
                catch (Exception e) { exceptions.Add(e); }
            }
            if (exceptions.Count == 0)
                return result;
            foreach (var i in result)
            {
                try { i.Dispose(); }
                catch (Exception e) { exceptions.Add(e); }
            }
            throw new AggregateException(exceptions);
        }
    }
