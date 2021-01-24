    public void TatilHesap()
            {
                //below is Local Variable 
                var holidays = new List<Holiday>();
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
