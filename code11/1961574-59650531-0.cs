    private static DateTime ParseDate(string providedDate)
    {
        DateTime validDate;
        string[] formats = { "dd.MM.yyyy" };
        var dateFormatIsValid = DateTime.TryParseExact(
          providedDate,
          formats,
          CultureInfo.InvariantCulture,
          DateTimeStyles.None,
          out validDate);
        return dateFormatIsValid ? validDate : DateTime.MinValue;
    }
