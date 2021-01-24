    currentPopulation = 
        SafeConvert(detailmetrics.FirstOrDefault(predicate)?.MetricValue);
    public double? SafeConvert(string value)
    {
        ... your implementation e.g. ...
        if (String.IsNullOrEmpty(value)) return null;
        if (Double.TryParse(value, ... out double result)) return result; 
        ... handle invalid double values ...
    }
