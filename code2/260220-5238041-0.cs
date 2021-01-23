    public static TOut ValueOrDefault<TIn, TOut>(this TIn input, Func<TIn, TOut> projection, TOut defaultValue)
            where TOut : class
        {
            try
            {
                return projection(input) ?? defaultValue;
            }
            catch (NullReferenceException)
            {
                return defaultValue;
            }
            catch (InvalidOperationException)
            {
                return defaultValue;
            }
        }
