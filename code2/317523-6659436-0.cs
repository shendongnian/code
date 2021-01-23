    public string ToCsv(IEnumerable items)
    {
        var csvBuilder = new StringBuilder();
        var properties = typeof(T).GetProperties().Where(prop => Columns[prop.Name].FileSize.IsVisible).OrderBy(prop => Column[prop.Name].FileSize.Index).ToArray();
        
        foreach (T item in items)
        {
            string line = string.Join(",",properties.Select(p => p.GetValue(item, null));
            csvBuilder.AppendLine(line);
        }
        return csvBuilder.ToString();
    }
    
