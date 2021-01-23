    public static class HttpExpiresFormat
    {
        private enum Month
        {
            Jan = 1, Feb = 2, Mar = 3, Apr = 4, May = 5, Jun = 6, Jul = 7, Aug = 8, Sept = 9, Oct = 10, Nov = 11, Dec = 12
        }
        public static string HttpExpireDate(double secondsToAdd)
        {
            DateTime dateTime = DateTime.Now;
            string dayOfWeek = ConvertDayToSmall(dateTime.DayOfWeek.ToString());
            string day = dateTime.Day < 10 ? "0" + dateTime.Day.ToString() : dateTime.Day.ToString();
            string month = ((Month)dateTime.Month).ToString();
            string year = dateTime.Year.ToString();
            char[] trim = new char[] { '.' };
            string substring = dateTime.AddHours(5).AddSeconds(secondsToAdd).TimeOfDay.ToString();
            string time = substring.Remove(substring.LastIndexOf('.')) + " GMT";
            return string.Format("{0}, {1} {2} {3} {4}", dayOfWeek, day, month, year, time);
        }
        private static string ConvertDayToSmall(string day)
        {
            switch (day)
            {
                case "Monday":
                    return "Mon";
                case "Tuesday":
                    return "Tue";
                case "Wednesday":
                    return "Wed";
                case "Thursday":
                    return "Thu";
                case "Friday":
                    return "Fri";
                default:
                    return null;
            }
        }
    }
}
