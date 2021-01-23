    var dateString = "1st February 2011";
    DateTime date;
    var replaced = dateString.Substring(0,4)
                             .Replace("nd","")
                             .Replace("th","")
                             .Replace("rd","")
                             .Replace("st","")
                             + dateString.Substring(4);
    DateTime.TryParseExact(replaced, "d MMMM yyyy",
                           new CultureInfo("en-us"), DateTimeStyles.AssumeLocal, 
                           out date);
