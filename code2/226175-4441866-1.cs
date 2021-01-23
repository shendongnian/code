    CultureInfo cultureInfo = new CultureInfo("en-US", true);
    string doubleMax = Double.MaxValue.ToString("R", cultureInfo);
    Console.WriteLine(doubleMax);
    double d;
    if (Double.TryParse(doubleMax, NumberStyles.Any, cultureInfo.NumberFormat, out d)) {
      if (d == Double.MaxValue) {
        Console.WriteLine("parsed");
      } else {
        Console.WriteLine("value changed");
      }
    } else {
      Console.WriteLine("couldn't parse");
    }
