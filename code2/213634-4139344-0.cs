      DateTime dt = DateTime.Parse("2010-11-09, Thuesday");
            while (dt < DateTime.MaxValue) 
            {
                
                if(dt.DayOfWeek == DayOfWeek.Sunday || dt.DayOfWeek == DayOfWeek.Monday)
                    Console.WriteLine(dt.ToString());
                dt.AddDays(1);
            }
