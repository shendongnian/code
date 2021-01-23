    public static class TimePeriod
    {
      public static DateTime Day{ get{return DateTime.Now.AddDays(-1);}},
      public static DateTime Week{ get{return DateTime.Now.AddDays(-7);}},
      public static DateTime Month{ get{return DateTime.Now.AddMonths(-1);}},
      public static DateTime AllTime{ get{return DateTime.Now;}},
    }
