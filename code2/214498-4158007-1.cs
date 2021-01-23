    public class Interval<T> where T : IComparable
    {
        public T Start { get; private set; }
        public T End { get; private set; }
        public bool HasStart { get; private set; }
        public bool HasEnd { get; private set; }
        private Interval()
        {
        }
        public bool Overlaps(Interval<T> other)
        {
            if (this.HasStart && other.IsInRange(this.Start))
                return true;
            if (this.HasEnd && other.IsInRange(this.End))
                return true;
            return false;
        }
        public static Interval<T> Merge(Interval<T> int1, Interval<T> int2)
        {
            if (!int1.Overlaps(int2))
            {
                throw new ArgumentException("Interval ranges do not overlap.");
            }
            bool hasStart = false;
            bool hasEnd = false;
            T start = default(T);
            T end = default(T);
            if (int1.HasStart && int2.HasStart)
            {
                hasStart = true;
                start = (int1.Start.CompareTo(int2.Start) < 0) ? int1.Start : int2.Start;
            }
            if (int1.HasEnd && int2.HasEnd)
            {
                hasEnd = true;
                end = (int1.End.CompareTo(int2.End) > 0) ? int1.Start : int2.Start;
            }
            return CreateInternal(start, hasStart, end, hasEnd);
        }
        private static Interval<T> CreateInternal(T start, bool hasStart, T end, bool hasEnd)
        {
            var i = new Interval<T>();
            i.Start = start;
            i.End = end;
            i.HasEnd = hasEnd;
            i.HasStart = hasStart;
            return i;
        }
        public static Interval<T> Create(T start, T end)
        {
            return CreateInternal(start, true, end, true);
        }
        public static Interval<T> CreateLowerBound(T start)
        {
            return CreateInternal(start, true, default(T), false);
        }
        public static Interval<T> CreateUpperBound(T end)
        {
            return CreateInternal(default(T), false, end, true);
        }
        public bool IsInRange(T item)
        {
            if (HasStart && item.CompareTo(Start) < 0)
            {
                return false;
            }
            if (HasEnd && item.CompareTo(End) >= 0)
            {
                return false;
            }
            return true;
        }
    }
