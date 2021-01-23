    public IEnumerable<Measurement> GetCurveDataForTestType()
    {
        // In .NET 4.0 you can use Zip here instead.
        for (int i = 0; i < voltage.Count(); i++)
        {
            yield return new Measurement
            {
                Voltage = voltage[i],
                Current = current[i]
            };
        }
    }
