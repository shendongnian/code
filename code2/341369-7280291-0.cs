    string []format = new string []{"yyyy-MM-dd HH:mm:ss"};
    string value = "2011-09-02 15:30:20";
    DateTime datetime;
    
    if (DateTime.TryParseExact(value, format, System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.NoCurrentDateDefault  , out datetime))
       Console.WriteLine("Valid  : " + datetime);
    else
      Console.WriteLine("Invalid");
