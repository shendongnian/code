        DateTime d1 = DateTime.Today;
        DateTime d2 = DateTime.Today.AddDays(3);
        if (d1.Year < d2.Year)
            Console.WriteLine("d1 < d2");
        else
            if (d1.DayOfYear < d2.DayOfYear)
                    Console.WriteLine("d1 < d2");
