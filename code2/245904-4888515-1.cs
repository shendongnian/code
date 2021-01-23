    public static class Extensions
    {
        public static IEnumerable<T> Traverse<T>(this Array array)
        {
            foreach (object val in array)
            {
                if (val == null)
                    continue; //null means empty sub-array --> skip it
                if (val is Array)
                {
                    var subArray = (Array)val;
                    foreach (var value in subArray.Traverse<T>())
                        yield return value;
                }
                else
                {
                    yield return (T)val;
                }
            }
            yield break;
        }
    }
