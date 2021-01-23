        public static TResult TryGetOrDefault<TSource, TResult>(this TSource obj, Func<TSource, TResult> function, TResult defaultResult = default(TResult))
        {
            try
            {
                defaultResult = function(obj);
            }
            catch (NullReferenceException) { }
            return defaultResult;
        }
