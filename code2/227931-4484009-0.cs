    public static class Extensions {
        public static string Format(this TimeSpan ts, string format) {
            var dt = new DateTime(Math.Abs(ts.Ticks));
            var result = dt.ToString(format);
            if (ts.Ticks < 0) result = "-" + result;
            return result;
        }
    }
