    string date ="20101121"; // 2010-11-21
    string time ="13:11:41"; //HH:mm:ss
    DateTime dateValue;
    if (DateTime.TryParseExact(date + " " + time, "yyyyMMdd HH:mm:ss", new CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out dateValue))
    {
        Console.Write(dateValue.ToString());
    }
    else
    {
        Console.Write(dateValue.ToString());
    }
