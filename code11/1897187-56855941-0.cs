      string[] data =
      {
        "AB1234", // True
        "XA3456", // True
        "3d34hg", // False
        " .1234", // False
        "ñÑ1234", // True
        "ôà1234", // True 
      };
      var matchess = data.Select(s => Regex.IsMatch(s, @"^[^\d\s\W]{2}\d{4}$"));
      foreach (bool result in matchess)
      {
        Console.WriteLine(result);
      }
