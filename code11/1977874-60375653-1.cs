    private static DateTime ParseDate(string providedDate)
    {
        DateTime validDate;
        string[] formats = {  "dd/MM/yyyy hh:mm:ss", "yyyy-MM-dd'T'hh:mm:ss'Z'" };
        var dateFormatIsValid = DateTime.TryParseExact(
            providedDate,
            formats,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out validDate);
        return dateFormatIsValid ? validDate : DateTime.MinValue;
    }
