    private static Dictionary<string, double> _DistanceLookup = new Dictionary<string, double>()
    {
      {"mile", 1609.344},
      {"furlong", 201.168},
      {"yard", 0.9144},
      {"inch", 0.0254},
      {"foot", 0.3048},
      {"feet", 0.3048},
      {"kilometer", 1000},
      {"kilometre", 1000},
      {"metre", 1},
      {"meter", 1},
      {"centimeter", 0.01},
      {"centimetre", 0.01},
      {"millimeter", 0.001},
      {"millimetre", 0.001},
    };
    private static double ConvertFraction(string fraction)
    {
      double value = 0;
      if (fraction.Contains('/'))
      {
        // If the value contains /, we need to work out the fraction
        string[] splitVal = fraction.Split('/');
        if (splitVal.Length != 2)
        {
          ScrewUp(fraction, "splitVal.Length");
        }
        // Turn the fraction into decimal
        value = double.Parse(splitVal[0]) / double.Parse(splitVal[1]);
      }
      else
      {
        // Otherwise it's a simple parse
        value = double.Parse(fraction);
      }
      return value;
    }
    public static double ExtractDistance(string distAsString)
    {
      double distanceInMeters = 0;
      /* This will have a match per unit type.
       * e.g., the string "1 1/16 Miles 3/4 Yards" would have 2 matches
       * being "1 1/16 Miles", "3/4 Yards".  Each match will then have 4
       * groups in total, with group 3 being the raw value and 4 being the
       * raw unit
       */
      var matches = Regex.Matches(distAsString, @"(([\d]+[\d\s\.,/]*)\s([A-Za-z]+[^\s\d]))");
      foreach (Match match in matches)
      {
        // If groups != 4 something went wrong, we need to rethink our regex
        if (match.Groups.Count != 4)
        {
          ScrewUp(distAsString, "match.Groups.Count");
        }
        string valueRaw = match.Groups[2].Value;
        string unitRaw = match.Groups[3].Value;
        // Firstly get the value
        double value = 0;
        if (valueRaw.Contains(' '))
        {
          // If the value contains /, we need to work out the fraction
          string[] splitVal = valueRaw.Split(' ');
          if (splitVal.Length != 2)
          {
            ScrewUp(distAsString, "splitVal.Length");
          }
          // Turn the fraction into decimal
          value = ConvertFraction(splitVal[0]) + ConvertFraction(splitVal[1]);
        }
        else
        {
          value = ConvertFraction(valueRaw);
        }
        // Now work out based on the unit type
        // Clean up the raw unit string
        unitRaw = unitRaw.ToLower().Trim().TrimEnd('s');
        if (!_DistanceLookup.ContainsKey(unitRaw))
        {
          ScrewUp(distAsString, "unitRaw");
        }
        distanceInMeters += value * _DistanceLookup[unitRaw];
      }
      return distanceInMeters;
    }
    private static void ScrewUp(string val, string prop)
    {
      throw new ArgumentException("Extract distance screwed up on string [" + val + "] (bad " + prop + ")");
    }
