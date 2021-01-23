    static readonly Regex FractionalExpression = new Regex(@"^(?<sign>[-])?(?<numerator>\d+)(/(?<denominator>\d+))?$");
    public static decimal? FractionToDecimal(string fraction)
    {
        var match = FractionalExpression.Match(fraction);
        if (match.Success)
        {
            // var sign = Int32.Parse(match.Groups["sign"].Value + "1");
            var numerator = Int32.Parse(match.Groups["sign"].Value + match.Groups["numerator"].Value);
            int denominator;
            if (Int32.TryParse(match.Groups["denominator"].Value, out denominator))
                return denominator == 0 ? (decimal?)null : (decimal)numerator / denominator;
            if (numerator == 0 || numerator == 1)
                return numerator;
        }
        return null;
    }
