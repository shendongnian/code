    public string CsvProjection(List<string> inputs, int neddleIndex, string neddleValue)
    {
        if (neddleIndex < 0)
        {
            throw new ArgumentException("neddleIndex must be positive.");
        }
        if (neddleIndex > inputs.Count())
        {//Either throw an exception because out of bound or add to the end
            inputs.Add(neddleValue);
        }
        inputs.Insert(neddleIndex, neddleValue);
        return string.Join(",", inputs);
    }
    
