    static DateTime Parse(string dateString)
    {
     string[] formats = new [] {"MMMYY\A\u\c", "MMMM YYYY"};
     DateTime parsedDate = new DateTime();
     foreach (string fmt in formats)
     {
        if (DateTime.TryParseExact (dateString, fmt, null, DateTimeStyles.Default, out parsedDate)
           return parsedDate;
     }
     throw new FormatException ();
    }
