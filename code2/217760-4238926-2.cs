    string date ="20101121"; // 2010-11-21
    string time ="13:11:41"; //HH:mm:ss
    DateTime value;
    if (DateTime.TryParseExact(
        date + time,
        "yyyyMMddHH':'mm':'ss", 
        new CultureInfo("en-US"),
        System.Globalization.DateTimeStyles.None,
        out value))
    {
        Console.Write(value.ToString());
    }
    else
    {
        Console.Write("Date parse failed!");
    }
