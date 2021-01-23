    string s = "20100229";
    DateTime result;
    if (!DateTime.TryParseExact(
         s,
         "yyyyMMdd",
         CultureInfo.InvariantCulture,
         DateTimeStyles.AssumeUniversal,
         out result))
    {
        Console.WriteLine("Invalid date entered.");
    };
