    public static class DateFormat
    {
        static DateFormat()
        {
            DateFormats.Add("yyyy{0}MM{0}dd HH{1}mm{1}ss");
            DateFormats.Add("yyyy{0}MM{0}dd hh{1}mm{1}ss");
            Current = DateFormats[1];
        }
        private static List<string> DateFormats = new List<string>();
        public static string DateSeparator { get; set; } = "/";
        public static string Current { get; set; }
    }
