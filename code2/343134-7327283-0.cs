    class Range<T> where T : IComparable<T>
    {
        public T Start { get; private set;}
        public T End { get; private set;}
        public Range(T start, T end)
        {
            //Always ensure that Start < End
            if(start.CompareTo(end) >= 0)
            {
                var temp = end;
                end = start;
                start = temp;
            }
            Start = start;
            End = end;
        }
    }
    static class Range
    {
        public static bool Overlap<T>(Range<T> left, Range<T> right)
            where T : IComparable<T>
        {
            if (left.Start.CompareTo(right.Start) == 0)
            {
                return true;
            }
            
            else if (left.Start.CompareTo(right.Start) > 0)
            {
                return left.Start.CompareTo(right.End) <= 0;
            }
            else
            {
                return right.Start.CompareTo(left.End) <= 0;
            }
        }
    }
