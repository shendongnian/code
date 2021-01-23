            DateTime d = new DateTime(someYear, 1, 1);
            d.AddDays(numWeeks * 7);
            for (int x = 0; x < 7; x++)
            {
                Console.WriteLine(d.ToShortDateString());
                d.AddDays(1);
            }
