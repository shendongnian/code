    DateTime start = DateTime.Parse("15/02/2011 16:00");
                DateTime end = DateTime.Parse("16/02/2011 10:00");
    
                int count = 0;
    
                for (var i = start; i < end; i = i.AddHours(1))
                {
                    if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (i.TimeOfDay.Hours >= 9 && i.TimeOfDay.Hours < 17)
                        {
                            count++;
                        }
                    }
                }
    
                Console.WriteLine(count);
