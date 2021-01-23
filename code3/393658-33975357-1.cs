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
