    int yearCount = 0;
    int monthCount = 0;
    int earliestYear = 0;
    int earliestMonth = 0;
    int latestYear = 0;
    int latestMonth = 0;
    // Get the earlier date, assuming that you haven't calculated which date is the latter already.
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
    // Get the years between (remember not to include a year where the earlier dates month is greater than the latter. E.g. 09/2011 -> 01/2013 will only be 1 year, not 2!
    while(earliestYear < latestYear && (earliestMonth <= latestMonth || earliestYear < (latestYear - 1)))
    {
       yearCount++;
       earliestYear++;
    }
    
    // Finally get the months between, moving back to january after december.
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
