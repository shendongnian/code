        static IEnumerable<T> RunEnumerator<T>(Func<IEnumerator<T>> generator, 
            Action<Exception> onException)
        {
            using (var enumerator = generator())
            {
                if (enumerator == null) 
                    yield break;
                for (; ; )
                {
                    T value;
                    try
                    {
                        if (enumerator.MoveNext())
                            value = enumerator.Current;
                        else
                            yield break;
                    }
                    catch (Exception e)
                    {
                        onException(e);
                        yield break;
                    }
                }
            }
        }
        public static IEnumerable<T> WithExceptionHandler<T>(this IEnumerable<T> orig, 
            Action<Exception> onException)
        {
            return RunEnumerator(() =>
            {
                try
                {
                    return orig.GetEnumerator();
                }
                catch (Exception e)
                {
                    onException(e);
                    return null;
                }
            }, onException);
        }
    }
