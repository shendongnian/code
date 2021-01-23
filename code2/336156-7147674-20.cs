    public static IEnumerable<T> PivotRange<T>(
        this IEnumerable<T> source, T pivot, int size) where T : IComparable<T>
    {
        T[] left = new T[size];
        int lCount = 0, rCount = 0;
        IEnumerator<T> enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            T item = enumerator.Current;
            if (item.CompareTo(pivot) == 0)
            {
                int start = lCount > size ? lCount % size : 0;
                for (int j=start, i=0; i < size && i < lCount; j = ++j % size, i++)
                    yield return left[j];
                yield return pivot;
                while (enumerator.MoveNext() && rCount++ < size)
                    yield return enumerator.Current;
                break;
            }
            if (size <= 0) continue;
            left[lCount++ % size] = item;
        }
    }
