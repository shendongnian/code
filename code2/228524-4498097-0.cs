    string input = "20/12/2010"; // dd/mm/yyyy
    DateTime d;
    if (DateTime.TryParseExact(input, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out d))
    {
    	string result = d.ToString("yyyy/mm/dd");
    }
