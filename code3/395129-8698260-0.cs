    public string GetQuarter(DateTime date)
    {
       // we just need to check the month irrespective of the other parts(year, day)
       // so we will have all the dates with year part common
       DateTime dummyDate = new DateTime(1900, date.Month, date.Day);
    
       if (dummyDate < new DateTime(1900, 7, 1) && dummyDate >= new DateTime(1900, 4, 1))
       {
          return "Q1";
       }
       else if (dummyDate < new DateTime(1900, 10, 1) && dummyDate >= new DateTime(1900, 7, 1))
       {
           return "Q2";
       }
       else if (dummyDate < new DateTime(1900, 1, 1) && dummyDate >= new DateTime(1900, 10, 1))
       {
           return "Q3";
       }
       else
       {
           return "Q4";
       }
    }
