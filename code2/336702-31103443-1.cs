            DateTime date = DateTime.Now;
            Console.WriteLine(date);
            // Sunday 28.06.2015 г. 10:22:41 ч.
            int monthsBack = -1;
            int whichDay = 1;
            // It means -> what day the first day of the previous month is.
            DayOfWeek FirstDayOfWeek = date.AddMonths(monthsBack).AddDays(whichDay).DayOfWeek;
            Console.WriteLine(FirstDayOfWeek);
            // Friday
            int delta = DayOfWeek.Monday - date.AddMonths(monthsBack).AddDays(whichDay).DayOfWeek;
            Console.WriteLine(delta);
            // -4
            //-4 ->Monday , -3 ->Tuesday, -2 ->Wednesday , -1 ->Thursday, 0 ->Friday
