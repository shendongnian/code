    public static class DayOfWeekExtensions
    {
        public static string ToCurrentCultureString(this DayOfWeek dayOfWeek)
        {
            // Or CurrentUICulture... I can never remember which way round they are.
            var formatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
            return formatInfo.DayNames[(int) dayOfWeek];
        }
    }
