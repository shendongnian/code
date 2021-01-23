    public static class EnumerableExtensions {
        public static IEnumerable<IterationElement<T>> Detailed<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            using (var enumerator = source.GetEnumerator())
            {
                bool isFirst = true;
                bool hasNext = enumerator.MoveNext();
                int index = 0;
                while (hasNext)
                {
                    T current = enumerator.Current;
                    hasNext = enumerator.MoveNext();
                    yield return new IterationElement<T>(index, current, isFirst, !hasNext);
                    isFirst = false;
                    index++;
                }
            }
        }
    
        public struct IterationElement<T>
        {
            public int Index { get; }
            public bool IsFirst { get; }
            public bool IsLast { get; }
            public T Value { get; }
            public IterationElement(int index, T value, bool isFirst, bool isLast)
            {
                Index = index;
                IsFirst = isFirst;
                IsLast = isLast;
                Value = value;
            }
        }
    }
