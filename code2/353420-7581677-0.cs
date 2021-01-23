    public static class TypeExtensions
    {
        public static bool IsValidDecimal(this string s)
        {
            decimal result;
            return Decimal.TryParse(s, out result);
        }
    }
