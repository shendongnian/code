    string input = "21-12-2010"; // dd-MM-yyyy    
    DateTime d;
    if (DateTime.TryParseExact(input, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out d))
    {
        // use d
    }
