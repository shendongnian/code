    public IEnumerable<Measurement> GetCurveDataForTestType()
    {
        for (int i = 0; i < voltage.Count(); i++)
        {
            yield return new Measurement
            {
                Voltage = voltage[i],
                Current = current[i]
            };
        }
    }
