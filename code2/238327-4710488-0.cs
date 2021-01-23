    static bool IsTimeValid(string time)
    {
      DateTime dt;
      return DateTime.TryParseExact(time, "HHmmss", 
        System.Globalization.CultureInfo.InvariantCulture, 
        System.Globalization.DateTimeStyles.None, out dt);
    }
