    var format = "yy-MM-dd hh:mm:ss";
    var dateFromDB = "19-08-26 08:23:45";
    DateTime.TryParseExact(
        dateFromDB, 
        format, 
        System.Globalization.CultureInfo.InvariantCulture, 
        System.Globalization.DateTimeStyles.None, 
        out DateTime result);
    Console.WriteLine(result.ToString("yyMMdd"));
