    // Simulated file containing one number per line in en-US culture
    string file = "2.3\n3.5\n5.7";
    // Assumed that files all use en-US culture for numbers
    System.Globalization.NumberFormatInfo numberFormat = CultureInfo.GetCultureInfo("en-US").NumberFormat;
    foreach (string line in file.Split('\n'))
    {
        // Parse en-US string to double
        double number = double.Parse(line, numberFormat);
        // Debugging/Logging using thread's current culture
        Debug.WriteLine(number.ToString("F1"));
        // Write to console or possibly another file in en-US culture
        Console.WriteLine(number.ToString("F1", numberFormat));
    }
