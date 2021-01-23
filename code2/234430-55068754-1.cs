    public static int GetTotalMonths(DateTime From, DateTime Till)
            {
                int MonthDiff = 0;
    
                for (int i = 0; i < 12; i++)
                {
                    if (From.AddMonths(i).Month == Till.Month)
                    {
                        MonthDiff = i + 1;
                        break;
                    }
                }
    
                return MonthDiff;
            }
