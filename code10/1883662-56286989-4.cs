    public string CsvProjection(List<string> inputs, int needleIndex, string needleValue)
    {
        if (needleIndex < 0)
        {
            throw new ArgumentOutOfRangeException("needleIndex must be positive.");
        }
        if (needleIndex > inputs.Count())
        {//Either throw an exception because out of bound or add to the end
            inputs.Add(needleValue);
        }
        inputs.Insert(needleIndex, needleValue);
        return string.Join(",", inputs);
    }
    
