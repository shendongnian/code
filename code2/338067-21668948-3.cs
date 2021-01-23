    static class EnumeratorHelper {
        //Don't forget that GetEnumerator() call can throw exceptions as well.
        //Since it is not easy to wrap this within a using + try catch block with yield,
        //I have to create a helper function for the using block.
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
                    //and you don't know weather it can be null,
                    //but you can always have a T[] with null value.
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
                    return null;
                }
            }, onException);
        }
    }
