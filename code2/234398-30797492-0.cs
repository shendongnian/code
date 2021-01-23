    int nMonths = 0;
    if (FDate.ToDateTime().Year == TDate.ToDateTime().Year)
         nMonths = TDate.ToDateTime().Month - FDate.ToDateTime().Month;                         
    else
    nMonths = (12 - FDate.Month) + TDate.Month;                          
