    public static decimal? ToDecimal1(this string source)
        {
            CultureInfo usCulture = new CultureInfo("en-US");
            if (string.IsNullOrEmpty(source.Trim1()))
                return null;
            else
                return Convert.ToDecimal(source.Replace(",", ".").Trim(), usCulture);
        }
