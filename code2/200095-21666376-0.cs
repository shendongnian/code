        static IEnumerable<T> RunEnumerator<T>(Func<IEnumerator<T>> generator, 
            Action<Exception> onException)
        {
            using (var enumerator = generator())
            {
                if (enumerator == null) 
                    yield break;
                for (; ; )
                {
                    bool valid = false;
                    try
                    {
                        valid = enumerator.MoveNext();
                    }
                    catch (Exception e)
                    {
                        onException(e);
                    }
                    if (valid)
                        yield return enumerator.Current;
                    else
                        yield break;
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
