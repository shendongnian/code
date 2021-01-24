    class TimeData
    {
        public TimeSpan Time { get; set; }
        public int Number { get; set; }
        public static TimeData Parse(string input)
        {
            var timeData = new TimeData();
            int number;
            TimeSpan time;
            if (string.IsNullOrWhiteSpace(input)) return timeData;
            var parts = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 2 && int.TryParse(parts[2], out number))
            {
                timeData.Number = number;
            }
            if (parts.Length > 3 && TimeSpan.TryParseExact(parts[3], "hh\\:mm\\:ss\\.fffff", 
                CultureInfo.CurrentCulture, out time))
            {
                timeData.Time = time;
            }
            return timeData;
        }
    }
