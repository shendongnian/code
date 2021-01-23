    string[] format = new string[] { "dd.MM.yyyy" };
    string value = "09.09.2011";
    DateTime datetime;
    
    if (DateTime.TryParseExact(value, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
          //Valid
    else
         //Invalid
