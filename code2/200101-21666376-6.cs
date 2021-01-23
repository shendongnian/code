        static IEnumerable<T> RunEnumerator<T>(Func<IEnumerator<T>> generator, 
            Action<Exception> onException)
        {
            using (var enumerator = generator())
            {
                if (enumerator == null) 
                    yield break;
                for (; ; )
                {
                    //Avoid creating a default value with
                    //unknown type T
                    T[] value = null;
                    try
                    {
                        if (enumerator.MoveNext())
                            value = new T[] { enumerator.Current };
                    }
                    catch (Exception e)
                    {
                        if (onException(e))
                            continue;
                    }
                    if (value != null)
                        yield return value[0];
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
