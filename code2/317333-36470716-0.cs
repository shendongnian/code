    /// <summary>
    /// Transform DateTime into short specified format
    /// </summary>
    /// <param name="strDateTime">string : input DateTime</param>
    /// <param name="cultureInfo"></param>
    /// <param name="strFormat">string - optional : ouput format - default "d"</param>
    /// <returns></returns>
    public static string ConvertDateTimeToShortDate(string strDateTime, CultureInfo cultureInfo, string strFormat="d")
    {
      var dateTime = DateTime.MinValue;
      return DateTime.TryParse(strDateTime, out dateTime) ? dateTime.ToString(strFormat, cultureInfo) : strDateTime;
    }
