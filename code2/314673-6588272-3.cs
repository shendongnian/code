    public override ScanItem Seach(string s)
    {
        var results = Items.Select(i => i.Seach(s)).Where(i => i != null).ToList();
        if (results.Any())
        {
            var result = (ScanDir)MemberwiseClone();
            result.Items = results;
            return result;
        }
        return null;
    }
