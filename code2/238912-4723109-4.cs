    public int DoCompareDateTimes(DateTime firstDate, DateTime secondDate)
    {
     int res;
    
     res = firstDate.Year.CompareTo(secondDate.Year); //Year is a property
     if (res != 0) return res;
     
     res = firstDate.Month.CompareTo(secondDate.Month);
     if (res != 0) return res;
     
     res = firstDate.Day.CompareTo(secondDate.Day);
     if (res != 0) return res;
       
     res = this.Hours.CompareTo(dt.Hours);
     if (res != 0) return res;
     
     res = this.Minutes.CompareTo(dt.Minutes);
     if (res != 0) return res;
       
     return 0;
    }
    var test = DoCompareDateTimes(new DateTime(8,11,2011,20,30), new Date(1, 2, 2011));
