    public static IEnumerable<T> PivotRange<T>(
        this IEnumerable<T> source, T pivot, int size) where T : IComparable<T>
        {
            T[] left = new T[size];
            int leftIdx = 0;
            IEnumerator<T> enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T item = enumerator.Current;
                
                if (item.CompareTo(pivot) == 0)
                {
                    int leftStart = leftIdx % size;
                    for (int j = leftStart; j >= leftStart - 1 && j < leftIdx; j--)
                    {
                        yield return left[j];
                    }
                    yield return pivot;
                    int rightCount = 0;
                    while (enumerator.MoveNext() && rightCount++ < size)
                        yield return enumerator.Current;
                    break;
                }
                left[leftIdx++ % size] = item;
            }
        }
