    public static IEnumerable<T> PivotRange<T>(this IEnumerable<T> source, T pivot, int size) where T : IComparable<T>
        {
            T[] left = new T[size];
            int idx = 0, rightCount = 0;
            IEnumerator<T> enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T item = enumerator.Current;
                if (item.CompareTo(pivot) == 0)
                {
                    if (size > 0)
                    {
                        int i = idx % size;
                        for (int j = i; j >= i - 1 && j < idx; j--)
                            yield return left[j];
                    }
                    yield return pivot;
                    while (enumerator.MoveNext() && rightCount++ < size)
                        yield return enumerator.Current;
                    break;
                }
                if (size <= 0) continue;
                
                left[idx++ % size] = item;
            }
        }
