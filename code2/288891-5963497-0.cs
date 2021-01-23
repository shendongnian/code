    public decimal? CustomParse(string incomingValue)
    {
        decimal val;
        if (!decimal.TryParse(incomingValue.Replace(",", "").Replace(".", ""), NumberStyles.Number, CultureInfo.InvariantCulture, out val))
            return null;
        return val / 100;
    }
