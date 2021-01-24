        Private static DateTime? ParseUserInputDate(string providedDate)
        {
            DateTime validDate;
            string[] formats = { "d/M/yyyy h:mm:ss tt", "d/M/yyyy" };
            var dateFormatIsValid = DateTime.TryParseExact(
              providedDate,
              formats,
              CultureInfo.InvariantCulture,
              DateTimeStyles.None,
              out validDate);
            return dateFormatIsValid ? validDate : (DateTime?)null;
        }
