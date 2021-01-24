    var ukCulture = System.Globalization.CultureInfo.GetCultureInfo("en-gb");
    string dat = "11-01-2019";
    DateTime parsedDate;
    if (DateTime.TryParse(dat, ukCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
    {
        string date = parsedDate.ToString("dd MMM yyyy");
        Console.WriteLine(date);
    }
    else
    {
        Console.WriteLine("invalid date");
    }
