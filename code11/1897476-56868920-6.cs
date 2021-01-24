    public static Interval MergeWith(this Interval interval1, Interval interval2)
        => new Interval
        {
            From = new DateTime(Math.Min(interval1.From.Ticks, interval2.To.Ticks)),
            To = new DateTime(Math.Max(interval1.From.Ticks, interval2.To.Ticks))
        };
