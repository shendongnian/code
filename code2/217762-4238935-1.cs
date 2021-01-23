    using System.Globalization;
    string date = "20101121"; // 2010-11-21
    string time = "13:11:41"; // HH:mm:ss
    
    DateTime convertedDateTime;
    bool conversionSucceeded = DateTime.TryParseExact(date + time,
        "yyyyMMddHH':'mm':'ss", CultureInfo.InvariantCulture,
        DateTimeStyles.None, out convertedDateTime);
