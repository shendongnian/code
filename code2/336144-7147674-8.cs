    public static IEnumerable<T> PivotRange<T>(
        this IEnumerable<T> source, T pivot, int size) where T : IComparable<T>
        {
            T[] left = new T[size];
            int left = 0, rightCount = 0;
            IEnumerator<T> enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T item = enumerator.Current;
                if (item.CompareTo(pivot) == 0)
                {
                    if (size > 0)
                    {
                        for (int i = left % size; i >= start - 1 && i < left; i--)
                            yield return left[i];
                    }
                    yield return pivot;
                    while (enumerator.MoveNext() && rightCount++ < size)
                        yield return enumerator.Current;
                    break;
                }
                if (size <= 0) continue;
                
                left[left++ % size] = item;
            }
        }
