            var workingDate = new DateTime(2011, 4, 1);
            while (workingDate < DateTime.Today)
            {
                workingDate = workingDate.AddDays(1);
                Console.WriteLine(string.Format("{0:yyyyMMdd}", workingDate));
            }
