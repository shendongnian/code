      using System.Linq;  
      using System.Text.RegularExpressions;
      ...
      string test =    
        @"main(volatage1, voltage2, current)   0,017   0,77    v   100  I";
      Regex regex = new Regex(@"\b[0-9]+(?:\,[0-9]+)?\b");
      double[] values = regex
        .Matches(test)
        .Cast<Match>()
        .Select(match => double.Parse(match.Value, CultureInfo.GetCultureInfo("de-DE")))
        .ToArray();
