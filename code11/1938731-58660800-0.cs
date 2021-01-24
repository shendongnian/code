        private static DateTime ParseDate(string providedDate)
        {
            DateTime validDate;
            string[] formats = { "yyyy-MM-ddTHH:mm:ss" };
            var dateFormatIsValid = DateTime.TryParseExact(
              providedDate,
              formats,
              CultureInfo.InvariantCulture,
              DateTimeStyles.None,
              out validDate);
            return dateFormatIsValid ? validDate : DateTime.MinValue;
        }
