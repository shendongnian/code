    public IEnumerable<string> GetIndexValue(string name)
    {
        var indices = metadataFile.Descendants("Index")
                .Where(e => e.Attribute("Name").Value == name);
        var codes = indices.Descendants("Code");
        return (codes.Any()) ? codes.Select(e => e.Value) 
                             : indices.Select(e => e.Value);
    }   
