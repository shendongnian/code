        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.Subtract(ParseDate("20190903T114500,000")).TotalMinutes);
        }
        private static DateTime ParseDate(string providedDate)
        {
            DateTime validDate;
            string[] formats = { "yyyyMMddTHHmmss,fff" };
            var dateFormatIsValid = DateTime.TryParseExact(
              providedDate,
              formats,
              CultureInfo.InvariantCulture,
              DateTimeStyles.None,
              out validDate);
            return dateFormatIsValid ? validDate : DateTime.MinValue;
        }
