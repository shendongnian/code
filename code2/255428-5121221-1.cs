    List<string> voltage = new List<string>() { "1", "5", "500" , "LT", "RT", "400" };
    List<string> result = voltage
      .OrderBy(s =>
      {
        int i = 0;
        return int.TryParse(s, out i) ? i : int.MaxValue;
      })
      .ThenBy(s => s)
      .ToList();
