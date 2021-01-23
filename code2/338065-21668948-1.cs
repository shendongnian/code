    static class EnumeratorHelper {
        private static IEnumerable<T> RunEnumerator<T>(Func<IEnumerator<T>> generator, 
            Func<Exception, bool> onException)
        {
            using (var enumerator = generator())
            {
                if (enumerator == null) 
                    yield break;
                for (; ; )
                {
                    //You don't know how to create a value of T,
                    //but you can always create a T[].
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
            Func<Exception, bool> onException)
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
                    return null; //or return Enumerable.Empty<string>();
                    //or you can use return value of onException to decide
                }
            }, onException);
        }
    }
