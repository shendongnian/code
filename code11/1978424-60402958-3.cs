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
      return MustQuote(field)
        ? @"""" + field.Replace(@"""",@"""""") + @""""
        : field;
    }
    public static bool MustQuote(string field) => 
      field.Any(c=>c == ',' || c == '"' || c == 13 || c == 10);
