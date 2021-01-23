    public IEnumerable<string> GetUpdatedLines(string fileName)
    {
        int? lastValue = null;
        foreach (string line in File.ReadLines(fileName))
        {
            var values = line.Split(',');
            int myIValue = Convert.ToInt32(values[7]);
            if (lastValue.HasValue && myIValue != lastValue)
            {
                //emit new line sum
                values[2] = "A001";
                yield return string.Join(",", values);
            }
            lastValue = myIValue;
            yield return line;
        }
    }
