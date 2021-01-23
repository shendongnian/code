    DateTime value;
    if (DateTime.TryParseExact(
      date + time,
      "dd/MM/yyyy", 
      new CultureInfo("en-GB"),
      System.Globalization.DateTimeStyles.None,
      out value))
    {
      Console.Write(value.ToString("yyyy/MM/dd"));
    }
    else
    {
      Console.Write("Date parse failed!");
    }
