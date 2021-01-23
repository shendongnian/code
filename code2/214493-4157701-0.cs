    public class Interval<T> where T : IComparable
    {
        public Nullable<T> Start { get; set; }
        public Nullable<T> End { get; set; }
    
        public Interval(T start, T end)
        {
            Start = start;
            End = end;
        }
    
        public bool InRange(T value)
        {
            return ((!Start.HasValue || value.CompareTo(Start.Value) > 0) &&
                    (!End.HasValue || End.Value.CompareTo(value) > 0));
        }
    }
