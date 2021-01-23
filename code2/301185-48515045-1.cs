    public static Dictionary<string, int> TimeSpanToDateParts(DateTime fromDate,DateTime toDate)
            {
                int years;
                int months;
                int days;
                Dictionary<string, int> dateParts = new Dictionary<string, int>();
                if (toDate < fromDate)
                {
                   return TimeSpanToDateParts(toDate,fromDate);
                }
    
                var span = toDate - fromDate;
    
                months = 12 * (toDate.Year - fromDate.Year) + (toDate.Month - fromDate.Month);
    
                if (toDate.CompareTo(fromDate.AddMonths(months).AddMilliseconds(-500)) <= 0)
                {
                    --months;
                }
    
                years = months / 12;
                months -= years * 12;
    
                if (months == 0 && years == 0)
                {
                    days = span.Days;
                }
                else
                {
                    days = toDate.Day;
                    if (fromDate.Day > toDate.Day)
                        days = days + (DateTime.DaysInMonth(toDate.Year, toDate.Month - 1) - fromDate.Day);
                    else
                        days = days - fromDate.Day;
                }
                dateParts.Add("Years", years);
                dateParts.Add("Months", months);
                dateParts.Add("Days", days);
    
                return dateParts;
            }
