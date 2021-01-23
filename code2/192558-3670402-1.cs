    public string[] GetResults(string someQuery, int pageNum, int pageSize)
    {
        var results = new List<string>();
    
        // Fill Results
        return results.Skip(pageNum * pageSize).Take(pageSize).ToArray();
    }
