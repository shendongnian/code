    decimal ParseDecimal(string number)
    {
        if (number.Equals("0E+3", StringComparison.OrdinalIgnoreCase))
        {
            return 0;
        }
        return decimal.Parse(number, System.Globalization.NumberStyles.Any);
    }
