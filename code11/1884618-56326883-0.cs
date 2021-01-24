    public static DateTime TatDueDateCalculator(DateTime assigningDate, int tatCount, IEnumerable<DateTime> holidays)
        {
            HashSet <DateTime> holidayLookup = new HashSet<DateTime>(holidays.Select(dt => dt.Date));
            DateTime dueDate = assigningDate.Date;
            while (tatCount > 1)
            {
                dueDate = dueDate.AddDays(1);
                while (holidayLookup.Contains(dueDate))
                    dueDate = dueDate.AddDays(1);
                tatCount--;
            }
            return dueDate;
        }
