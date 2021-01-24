        public void ConvertTimes()
        {
            string Timezone = "AUS Eastern Standard Time";
            TimeZoneInfo ESTZone = TimeZoneInfo.FindSystemTimeZoneById(Timezone);
            DateTime date = Convert.ToDateTime("2019-01-23 13:15:23.6090752");
            DateTime SydneyDateTime = TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.FindSystemTimeZoneById(Timezone));
            string EST = SydneyDateTime.ToString() + " / " + SydneyDateTime.IsDaylightSavingTime().ToString() + " / " + ESTZone.IsDaylightSavingTime(SydneyDateTime) + " / " + ESTZone.DaylightName + " / " + ESTZone.StandardName;
            DateTime IndiaDateTime = TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            DateTime date2 = Convert.ToDateTime("2019-05-23 13:15:23.6090752");
            DateTime SydneyDateTime2 = TimeZoneInfo.ConvertTimeFromUtc(date2, TimeZoneInfo.FindSystemTimeZoneById(Timezone));
            string EST2 = SydneyDateTime2.ToString() + " / " + SydneyDateTime2.IsDaylightSavingTime().ToString() + " / " + ESTZone.IsDaylightSavingTime(SydneyDateTime2) + " / " + ESTZone.DaylightName + " / " + ESTZone.StandardName;
        }
