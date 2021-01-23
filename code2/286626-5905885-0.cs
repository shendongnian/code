    //Convert DateTime to string
    string dateFormat = "d/MM/yyyy";
    string date1 = new DateTime(2008, 10, 5).ToString(dateFormat);
    string date2 = new DateTime(2008, 10, 12).ToString(dateFormat);
    
    //Convert back to DateTime
    DateTime x1, x2;
    DateTime.TryParseExact(date1, dateFormat, null, System.Globalization.DateTimeStyles.None, out x1);
    DateTime.TryParseExact(date2, dateFormat, null, System.Globalization.DateTimeStyles.None, out x2);
    
    Console.WriteLine(x1);
    Console.WriteLine(x2);
