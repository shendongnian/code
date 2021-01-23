    /// <summary>Returns the first element from the input sequence for which the
    /// value selector returns the smallest value.</summary>
    public static T MinElement<T>(this IEnumerable<T> source,
                                  Func<T, int> valueSelector)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (valueSelector == null)
            throw new ArgumentNullException("valueSelector");
        using (var enumerator = source.GetEnumerator())
        {
            if (!enumerator.MoveNext())
                throw new InvalidOperationException("source contains no elements.");
            T minElem = enumerator.Current;
            int minValue = valueSelector(minElem);
            while (enumerator.MoveNext())
            {
                int value = valueSelector(enumerator.Current);
                if (value < minValue)
                {
                    minValue = value;
                    minElem = enumerator.Current;
                }
            }
            return minElem;
        }
    }
