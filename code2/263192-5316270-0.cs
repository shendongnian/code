    public class MyDataObject
    {
      public string Value1 { get; set; }
      public string Value2 { get; set; }
      public string Value3 { get; set; }
    
      public bool MatchesSearchTerm(string term)
      {
        return Value2.Equals(term, StringComparer.OrdinalIgnoreCase);
      }
    }
