      private readonly static int[] thirdfridays =
          new int[] { 20, 19, 18, 17, 16, 15, 21 };
      public static int GetThirdFriday(int year, int month)
      {
         DateTime baseDay = new DateTime(year, month, 15);
         return thirdfridays[(int)baseDay.DayOfWeek];
      }
