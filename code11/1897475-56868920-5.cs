    static class IntervalExtensions
    {
        public static bool Overlaps(this Interval interval1, Interval interval2)
            => interval1.From <= interval2.From
               ? interval1.To >= interval2.From : interval2.To >= interval1.From;
    }
