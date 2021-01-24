    class Program
    {
        static void Main(string[] args)
        {
            var i = Parse<int>("100");
            var x = Parse<double>("3.1417");
            var s = Parse<string>("John");
            var d = Parse<Decimal>("1234.56");
            var f = Parse<DateTime>("4/1/2044");
            var q = Parse<byte>("4A");
            Decimal? p = Parse<decimal>("Not Decimal");
        }
        public static dynamic Parse<T>(string text)
        {
            var toType = typeof(T);
            if (toType == typeof(int))
            {
                if (int.TryParse(text, out int x))
                {
                    return x;
                }
            }
            else if (toType == typeof(short))
            {
                if (short.TryParse(text, out short x))
                {
                    return x;
                }
            }
            else if (toType == typeof(double))
            {
                if (double.TryParse(text, out double x))
                {
                    return x;
                }
            }
            else if (toType == typeof(decimal))
            {
                if (decimal.TryParse(text, out decimal x))
                {
                    return x;
                }
            }
            else if (toType == typeof(DateTime))
            {
                if (DateTime.TryParse(text, out DateTime x))
                {
                    return x;
                }
            }
            else if (toType == typeof(byte))
            {
                if (byte.TryParse(text, System.Globalization.NumberStyles.HexNumber, null, out byte x))
                {
                    return x;
                }
            }
            else if (toType ==typeof(string))
            {
                return text;
            }
            return null;
        }
    }
