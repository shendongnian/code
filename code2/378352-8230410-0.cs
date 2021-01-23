    public double ConvertMeasure(string measure)
    {
        var re = new Regex(@"(?i)(?<value>[\d.]+)\s*(?<multiplier>[munp]?)\s*(?<unit>[avw]*)");
        var conversionFactors = new Dictionary<string, double> {
        { "", 1 }, 
        { "m", 1E3 }, 
        { "u", 1E6 }, 
        { "n", 1E9 }, 
        { "p", 1E12 } };
        var m = re.Match(measure);
                
        double value = Convert.ToDouble(m.Groups["value"].Value);
        return value / conversionFactors[m.Groups["multiplier"].Value.ToLower()];
    }
