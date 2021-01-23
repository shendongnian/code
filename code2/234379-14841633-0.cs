        public static int PayableMonthsInDuration(DateTime StartDate, DateTime EndDate)
        {
            int sy = StartDate.Year; int sm = StartDate.Month; int count = 0;
            do
            {
                count++;if ((sy == EndDate.Year) && (sm >= EndDate.Month)) { break; }
                sm++;if (sm == 13) { sm = 1; sy++; }
            }while ((EndDate.Year >= sy) || (EndDate.Month >= sm));
            return (count);
        }
