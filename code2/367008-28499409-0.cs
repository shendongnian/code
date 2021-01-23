                var day = new DateTime(year, month, i);
                if(day.DayOfWeek==DayOfWeek.Saturday)
                {
                    totalSaturdays++;
                }
            }
            Console.WriteLine(("Total Saturdays ="+totalSaturdays.ToString()));
            Console.ReadLine();
