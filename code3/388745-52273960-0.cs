    public static bool IsValid(int month, int year)
        {
            var DateTimeNow = DateTime.Now;
            var MonthNow = DateTimeNow.Month;
            var YearNow = DateTimeNow.Year;
            if (year >= YearNow)
            {
                if (year > YearNow)
                {
                    return true;
                }
                if (year == YearNow)
                {
                    if (month >= MonthNow)
                    {
                        return true;
                    }
                }       
            }            
            return false;
        }
