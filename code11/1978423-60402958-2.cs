    public string ToCsv(IEnumerable<IEnumerable<string>> input)
    {
      var sb = new StringBuilder();
      foreach(var line in input)
      {
        sb.AppendLine(string.Join(",",line.Select(f=>SafeQuote(f))));
      }
      return sb.ToString();
    }
    
    public string SafeQuote(string field)
    {
      return field.Any(c=>",\"\n".Contains(c)) 
        ? @"""" + field.Replace(@"""",@"""""") + @""""
        : field;
    }
