    public Dictionary<string, object> GetDifferences(A target)
    {
        Dictionary<string, object> differences = new Dictionary<string, object>();
        foreach (PropertyInfo pi in typeof(A).GetProperties())
        {
            if (!pi.GetValue(this, null).Equals(pi.GetValue(target, null)))
                differences.Add(pi.Name, pi.GetValue(target, null));
        }
        return differences;
    }
