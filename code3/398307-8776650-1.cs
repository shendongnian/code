    public static class DoubleExtentions
    {
        public static bool InRange(this double value, double from, double to)
        {
            return value > from && value < to;
        }
    }
