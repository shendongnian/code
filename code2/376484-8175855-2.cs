    public static IEnumerable<Tuple<T, T>> ToPairs<T>(IEnumerable<T> enumerable)
        {
            using (var enumerator = enumerable.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    var previous = enumerator.Current;
                    while (enumerator.MoveNext())
                    {
                        var current = enumerator.Current;
                        yield return new Tuple<T, T>(previous, current);
                        previous = current;
                    }
                }
            }
        }
