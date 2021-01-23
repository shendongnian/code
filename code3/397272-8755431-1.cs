    // First create a dictionary of changed company names for ~O(1) lookup.
    var replacements = CreateReplacementDictionary(dupespullList);
    
    // Now create the excel rows replacing company names as we go.
    var finalRows = datapullList.Select(d => CreateExcelRow(d, replacements)).ToList();
    // ToList is here so that if you iterate over the collection 
    // multiple times it doesn't create new excel rows each time
    
    private static IDictionary<string, IDictionary<string, string>> CreateReplacementDictionary(IEnumerable<T> dupesList)
    {
      // First key is company name, second is location.
      var replacementDictionary = new Dictionary<string, Dictionary<string, string>>();
      foreach(var dupe in dupesList)
      {
        var name = dupe.GetString(0);
        if (!replacementDictionary.Keys.Contains(name))
        {
          replacementDictionary.Add(name, new Dictionary<string,string>());
        }
        
        replacementDictionary[name].Add(dupe.GetString(1), dupe.GetString(4));
      }
    
      return replacementDictionary;
    }
    private static ExcelRow CreateExcelRow(T data, IDictionary<string, IDictionary<string, string>> replacements)
    {
      var name = data.GetString(0);
      var location = data.GetString(1);
    
      IDictionary<string, string> replacementDictionary;
      if (replacements.TryGetValue(companyName, out replacement))
      {
        string replacementName;
        if (replacement.TryGetValue(location, out replacementName)
        {
          name = replacementName;
        }
      }
    
      return new ExcelRow 
                  {
                   Company = name, 
                   Location = location,
                   ItemPrice = data.GetString(4), 
                   SQL_Ticker = data.GetString(15)
                  };
    } 
