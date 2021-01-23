    public static DateTime AddBusinessDays(DateTime pActualDate, int pNumberofWorkDays)
            {
                ICollection<DateTime> holidays = GetAllHolidays();
                int i = default(int);
                while (i < pNumberofWorkDays)
                {
                    pActualDate = pActualDate.AddDays(1);
                    if (pActualDate.DayOfWeek == DayOfWeek.Saturday || pActualDate.DayOfWeek == DayOfWeek.Sunday
                        || (holidays != null && holidays.Contains(pActualDate))) { }
                    else
                    { i++; }
                }
                return pActualDate;
            }
    
    
    private static ICollection<DateTime> GetAllHolidays()
            {
                ICollection<DateTime> holidays = GetPublicHolidays().Select(s => s.Holidays).ToList<DateTime>();
                HashSet<DateTime> finalHolidays = new HashSet<DateTime>();
    
                //if sunday holiday then the following monday will be holiday
                bool isMonday = GetCalendar().Any(s => s.Type == "KR" && s.IsMonday);
    
                foreach (var hol in holidays)
                {
                    if (hol.DayOfWeek == DayOfWeek.Sunday && isMonday)
                    {
                        //adding monday following day holiday to the list
                        finalHolidays.Add(hol.AddDays(1));
                    }
                }
                //exclude weekends from the holiday list
                var excludeWeekends = holidays.Where(s => s.DayOfWeek == DayOfWeek.Sunday || s.DayOfWeek == DayOfWeek.Saturday);
                //adding monday to the existing holiday collection
                finalHolidays.UnionWith(holidays.Except(excludeWeekends));
                return finalHolidays;
            }
