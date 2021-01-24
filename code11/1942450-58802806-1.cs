            DateTime start = new DateTime(2019,11,1,0,0,0);
            DateTime end = new DateTime(2019, 11, 3, 11, 0, 0);
            TimeSpan diff = end - start;
            Console.WriteLine(diff.TotalDays);
            int total = 0;
            for (int i = 0; i<Math.Ceiling(diff.TotalDays); i++)
            {
                DateTime test = start.AddDays(i);
                Console.WriteLine(test.DayOfWeek);
                if (test.DayOfWeek == DayOfWeek.Saturday ||  test.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (test.Date==start.Date)
                    {
                        Console.WriteLine("start");
                        total += (23 - start.Hour) * 60 + (60 - start.Minute);
                    }
                    else if (test.Date==end.Date)
                    {
                        Console.WriteLine("end");
                        total += end.Hour * 60 + end.Minute;
                    }
                    else
                    {
                        
                        total += 24 * 60;
                    }
                }
                Console.WriteLine(test + " total " + total);
            }
            Console.WriteLine("done");
            Console.WriteLine(total);
