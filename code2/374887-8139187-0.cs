    int yearCount = 0;
    int monthCount = 0;
    int earliestYear = 0;
    int earliestMonth = 0;
    int latestYear = 0;
    int latestMonth = 0;
    // Get the earlier date
    if (myDate1 > myDate2)
    {
       earliestYear = myDate2.Year;
       earliestMonth = myDate2.Month;
    }
    else
    {
       latestYear = myDate1.Year;
       latestMonth = myDate1.Month;
    }
    while(earliestDatesYear  < latestYear || (earliestMonth > latestMonth && earliestYear < (latestYear - 1)))
    {
       yearCount++;
       earliestYear++;
    }
    
    while (earliestMonth != latestMonth)
    {
       monthCount++;
    
       if (earliestMonth == 12)
       {
          earliestMonth = 1;
       }
       else
       {
          earliestMonth++;
       }
    }
    string.Format("{0} years and {1} months", yearCount, monthCount);
