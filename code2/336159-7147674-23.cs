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
                int end = Math.Min(size, lCount);
                for (int i = start; i < start + end; i++)
                    yield return left[i % size];
                yield return pivot;
                while (enumerator.MoveNext() && rCount++ < size)
                    yield return enumerator.Current;
                break;
            }
            if (size <= 0) continue;
            left[lCount++ % size] = item;
        }
    }
