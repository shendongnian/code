    class YourDatum 
    {
      int Id { get; set; }
      string Value1  { get; set; }
      string Value2 { get; set; }
    
      public bool Match(string term)
      {
          return Value2.ToUpperInvariant() == term.ToUpperInvariant();
      }
    }
    
    var cachedResults = new Dictionary<int, YourDatum>();
    
    //your database calls go here
    foreach (var dbRow in dbRows) 
    {
       cachedResults.Add(
          idFromDb, 
          new YourDatum {Id=idFromDb, Value1=valueFromDb1, Value2=valueFromDb2});
    }
    
    //find a match in the results later on...
    string searchTerm = "abcdef";
    List<YourDatum> matches= 
        (from datum in cachedResults where 
        datum.Match(searchTerm) select datum).ToList();
