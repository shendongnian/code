    public static List<string> GetMonths(DateTime StartDate)
      {
       List<string> MonthList = new List<string>();
       DateTime ThisMonth = DateTime.Now.Date;
    
       while (ThisMonth.Date > StartDate.Date)
       {
        MonthList.Add(ThisMonth.ToString("MMMM") + " " + ThisMonth.Year.ToString());
        ThisMonth = ThisMonth.AddMonths(-1);
       }
    
       return MonthList;
      }
