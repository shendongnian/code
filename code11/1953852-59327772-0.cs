     DateTime dateValue = new DateTime(2019, 12, 19);
            int getDayOfWeek = GetWeekNumberOfMonth(dateValue);
            //convert to ordinal 
           string ordinalWeekOfMonth = AddOrdinal(getDayOfWeek);
          Console.WriteLine(ordinalWeekOfMonth + " " + dateValue.DayOfWeek);//output like 2nd sunday
