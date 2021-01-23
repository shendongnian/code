    static void Main()
    {
      Dictionary<string, List<string>> SpecTimes = new Dictionary<string, List<string>>();
      List<string> times = new List<string>();
      int count = 0;
      times.Add = "000.00.00";
      times.Add = "000.00.00";
      times.Add = "000.00.00";
    
      string spec = "A101";
    
      SpecTimes.Add(spec,times);
      
      // check to make sure the key exists, otherwise you'll get an exception.
      if(SpecTimes.ContainsKey(spec))
      {
          count = SpecTimes[spec].Count;
      }
    }
