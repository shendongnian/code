        public string Get24HourTime(int hour, int minute, string ToD)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            if (ToD.ToUpper() == "PM") hour += 12;
            return new DateTime(year, month, day, hour, minute).ToString("HH:mm");
        }
