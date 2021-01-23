    public static class DecimalExtensions
    {
        public static Decimal Normalize(this Decimal value)
        {
            return value / 1.000000000000000000000000000000000m;
        }
    }
