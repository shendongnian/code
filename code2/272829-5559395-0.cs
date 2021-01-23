    public static class DateTimeExtensions {
        public static DateTime StartOfWeek(this DateTime date) {
            System.Globalization.CultureInfo culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            DayOfWeek dayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;
            return date.AddDays(dayOfWeek - date.DayOfWeek);
        }
    }
