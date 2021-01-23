    class YourData 
    {
      int Id { get; set; }
      string Value1  { get; set; }
      string Value2 { get; set; }
    
      public bool Match(string term)
      {
          return Value2.ToUpperInvariant() == term.ToUpperInvariant();
      }
    }
    
    var cachedResults = new Dictionary<int, YourData>();
    
    //your database calls go here
    cachedResults.Add(
       idFromDb, 
       new YourData {Id=idFromDb, Value1=valueFromDb1, Value2=valueFromDb2 });
    
    //find a match in the results later on...
    string searchTerm = "abcdef";
    List<YourData> matches= 
        (from data in cachedResults where 
        data.Match(searchTerm) select data).ToList();
