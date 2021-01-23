        DateTime StartDate = new DateTime(2011, 3, 30);
        DateTime EndDate = new DateTime(2011, 4, 5);
        int[] DaysPerMonth = new int[12];
        while (EndDate > StartDate)
        {
            DaysPerMonth[StartDate.Month]++;
            StartDate = StartDate.AddDays(1);
        }
