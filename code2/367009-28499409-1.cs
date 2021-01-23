            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int days= DateTime.DaysInMonth(year, month);
            int totalSaturdays = 0;
            for(int i=1;i<=days;i++)
            {
                var day = new DateTime(year, month, i);
                if(day.DayOfWeek==DayOfWeek.Saturday)
                {
                    totalSaturdays++;
                }
            }
            Console.WriteLine(("Total Saturdays ="+totalSaturdays.ToString()));
            Console.ReadLine();
