    DateTime AddBusinessDays(int noofDays, DateTime dtCurrent)
        {
            var holidays = new List<DateTime>() { new DateTime(2013, 10, 22), new DateTime(2013, 10, 28)};
    
            DateTime tempdt = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day);
            // if starting day is non working day adjust to next working day
            tempdt = ExcludeNotWorkingDay(tempdt, holidays);
    
            // if starting day is non working day adjust to next working day then minus 1 day in noofadding days
            if (tempdt.Date > dtCurrent.Date && !(noofDays == 0))
                noofDays = noofDays - 1;
    
            while (noofDays > 0)
            {   
                tempdt = tempdt.AddDays(1);
                // if day is non working day adjust to next working day
                tempdt = ExcludeNotWorkingDay(tempdt, holidays);
                noofDays = noofDays - 1;
            }
    
            return tempdt;
        }
        DateTime ExcludeNotWorkingDay(DateTime dtCurrent, List<DateTime> holidays)
        {
            while (!IsWorkDay(dtCurrent, holidays))
            {
                dtCurrent = dtCurrent.AddDays(1);
            }
            return dtCurrent;
        }
        bool IsWorkDay(DateTime dtCurrent, List<DateTime> holidays)
        {
            if ((dtCurrent.DayOfWeek == DayOfWeek.Saturday || dtCurrent.DayOfWeek == DayOfWeek.Sunday ||
                 holidays.Contains(dtCurrent)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
