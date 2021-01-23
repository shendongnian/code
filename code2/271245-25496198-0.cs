    public static class TimeSpanHelper
    {
        public static TimeSpan operator *(TimeSpan span, double factor)
        {
            return TimeSpan.FromMilliseconds(span.TotalMilliseconds * factor);
        }
    
        public static TimeSpan operator *(double factor, TimeSpan span)  // * is commutative
        {
            return TimeSpan.FromMilliseconds(span.TotalMilliseconds * factor);
        }
    
        public static TimeSpan operator /(TimeSpan span, double sections)
        {
            return TimeSpan.FromMilliseconds(span.TotalMilliseconds / factor);
        }
    
        public static double operator /(TimeSpan span, TimeSpan period)
        {
            return span.TotalMilliseconds / period.TotalMilliseconds);
        }
    
    }
