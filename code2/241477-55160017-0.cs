    public struct Range<T> where T : IComparable<T>
    {
        public Range(T start, T end)
        {
            Start = start;
            End = end;
        }
        public T Start { get; }
        public T End { get; }
        public bool Includes(T value) => Start.CompareTo(value) <= 0 && End.CompareTo(value) >= 0;
        public bool Includes(Range<T> range) => Start.CompareTo(range.Start) <= 0 && End.CompareTo(range.End) >= 0;
    }
