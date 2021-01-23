    var input = new[] { "01.0", "01.4", "01.5", "0.20", "02.5", 
                        "02.6", "03.0", "03.2" };
    var integers = input.Select(i => 
                             (int)double.Parse(i,
                             System.Globalization.CultureInfo.InvariantCulture))
                        .Distinct().ToArray();
