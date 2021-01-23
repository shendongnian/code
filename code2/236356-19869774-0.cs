        public TimeSpan GetTimeFromString(string timeString)
        {
            DateTime dateWithTime = DateTime.MinValue;
            DateTime.TryParse(timeString, out dateWithTime);
            return dateWithTime.TimeOfDay;
        }
