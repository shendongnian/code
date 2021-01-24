    string test = 
      "main(volatage1, voltage2, current) 147.123,456  ,770 -,1234e+23   v   100  I";
    // some mixture of digits, comma, dot, exp, pluses - possible number
    Regex regex = new Regex(@"(\-|\,|\b)[0-9\,\.eE\-\+]+\b");
    double[] values = regex
      .Matches(test)
      .Cast<Match>()
      .Select(match => double.TryParse(match.Value, 
                                       NumberStyles.Any,
                                       CultureInfo.GetCultureInfo("de-DE"), 
                                       out var v)
         ? v           // parsing succeeds 
         : double.NaN) // NaN - failed to parse
      .Where(item => !double.IsNaN(item))
      .ToArray();
    Console.Write(string.Join(Environment.NewLine, values);
