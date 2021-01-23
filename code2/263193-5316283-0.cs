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
    
    var results = new Dictionary<int, YourData>();
    
    //your database calls go here
    results.Add(
       idFromDb, 
       new YourData {id=idFromDb, value1=valueFromDb1, value1=valueFromDb1 });
