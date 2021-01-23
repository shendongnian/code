    public static class ExceptionExtensions
    {
        public static IEnumerable<T> innerExceptions<T>(this Exception ex)
            where T : Exception
        {
            var rVal = new List<T>();
            Action<Exception> lambda = null;
            lambda = (x) =>
            {
                var xt = x as T;
                if (xt != null)
                    rVal.Add(xt);
                if (x.InnerException != null)
                    lambda(x.InnerException);
                var ax = x as AggregateException;
                if (ax != null)
                {
                    foreach (var aix in ax.InnerExceptions)
                        lambda(aix);
                }
            };
            lambda(ex);
            return rVal;
        }
    }
