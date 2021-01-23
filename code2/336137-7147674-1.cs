    public static IEnumerable<int> PivotRange(
        this IEnumerable<int> source, int pivot, int size)
    {
        int[] left = new int[size];
        int leftIdx = 0;
        IEnumerator<int> enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            int item = enumerator.Current;
            if (item == pivot)
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
