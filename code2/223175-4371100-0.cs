    List<DateTime> dates = new List<DateTime>();
    
    string test = "Hello World.  Random date1 is 12/10/2010. Now 4 days later is 12/14/2010."
    var potentialDates = test.Split(" .",StringSplitOptions.RemoveEmptyEntries);
    foreach (string s in potentialDates)
    {
      DateTime d;
      if (DateTime.TryParseExact(s, "MM/dd/yyyy", out d))
      {
        dates.Add(d);
      }
    }
