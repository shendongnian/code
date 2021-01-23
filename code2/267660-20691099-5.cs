    public class DayFinder
            {
                //For example to find the day for 2nd Friday, February, 2016
                //=>call FindDay(2016, 2, DayOfWeek.Friday, 2)
                public static int FindDay(int Year, int Month, DayOfWeek Day, int Occurance)
                {
        
                   if (Occurance == 0 || Occurance > 5) throw new Exception("Occurance is invalid");
                    
                   DateTime FirstDayOfMonth = new DateTime(Year, Month, 1);
                    //Substract first day of the month with the required day of the week 
                   var daysneeded = (int)Day - (int)FirstDayOfMonth.DayOfWeek;
                    //if it is less than zero we need to get the next week day (add 7 days)
                   if (daysneeded < 0) daysneeded = daysneeded + 7;
                    //DayOfWeek is zero index based; multiply by the Occurance to get the day
                   var resultedDay =  (daysneeded + 1)+ (7*(Occurance-1));
                   
                   if(resultedDay > (FirstDayOfMonth.AddMonths(1) - FirstDayOfMonth).Days) throw new Exception(String.Format("No {0} occurance of {1} in the required month", Occurance, Day.ToString()));
            
                   return resultedDay; 
                }
            }
