    public static class DoubleExtentions
    {
        public static bool inRange(this double value, double from, double to)
        {
            return value > from && value < to;
        }
    }
