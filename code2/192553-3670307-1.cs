    public static class StringUtils
    {
        public static string ToCurrency(decimal value)
        {
            return value.ToString("C");
        }
        public static decimal FromCurrency(string value)
        {
            return decimal.Parse(value, NumberStyles.Currency);
        }
        public static decimal? FromCurrency(string value, decimal? defaultValue)
        {
            decimal num;
            if(decimal.TryParse(value, NumberStyles.Currency, null, out num))
                return num;
            return defaultValue;
        }
    }
