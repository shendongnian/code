        private List<Holiday> holidays = new List<Holiday>();         
        public void TatilHesap()
        {
            holidays.Add(new MonthDayBasedHoliday(1, 1));
            holidays.Add(new MonthDayBasedHoliday(04, 23));
            holidays.Add(new MonthDayBasedHoliday(05, 01));
            holidays.Add(new MonthDayBasedHoliday(05, 19));
            holidays.Add(new MonthDayBasedHoliday(07, 15));
            holidays.Add(new MonthDayBasedHoliday(08, 30));
            holidays.Add(new MonthDayBasedHoliday(10, 29));
            holidays.Add(new FixedDateBasedHoliday(new DateTime(2020, 05, 23)));
            holidays.Add(new FixedDateBasedHoliday(new DateTime(2020, 05, 24)));
            holidays.Add(new FixedDateBasedHoliday(new DateTime(2020, 05, 25)));
            holidays.Add(new FixedDateBasedHoliday(new DateTime(2020, 05, 26)));
        }
        private void BtnEkle_Click(object sender, EventArgs e) 
        {
            // now user can add an item into holidays
            //TODO: put relevant code here
            holidays.Add(new MonthDayBasedHoliday(1, 7)); 
        }
