    // First create a dictionary of changed company names for ~O(1) lookup.
    var changedNames = dupespullList.ToDictionary(d => d.GetString(0), d => d.GetString(4));
    
    // Now create the excel rows replacing company names as we go.
    var finalRows = datapullList.Select(d => 
      new ExcelRow
      {
       Company = ReplaceNameIfChanged(d.GetString(0), changedNames),
       Location = d.GetString(1), 
       ItemPrice = d.GetString(4), 
       SQL_Ticker = d.GetString(15)
      }).ToList();
    // ToList is here so that if you iterate over the collection 
    // multiple times it doesn't create new excel rows each time
    
    // Helper method (to make code neater):
    private static string ReplaceNameIfChanged(string companyName, IDictionary<string, string> replacements)
    {
      string replacement;
      return replacements.TryGetValue(companyName, out replacement) ? replacement : companyName;
    } 
