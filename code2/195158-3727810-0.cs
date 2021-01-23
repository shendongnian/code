    var masterDictionary = new Dictionary<string, Dictionary<DateTime, double>>(); 
    
    var query =
      from kvp1 in masterDictionary
      from kvp2 in kvp1.Value
      select new {TheString = kvp1.Key, TheDate = kvp2.Key, TheDouble = kvp2.Value };
    foreach(var x in query)
    {
      Console.WriteLine("{0} {1} {2}", x.TheString, x.TheDate, x.TheDouble);
    }
