     public static DateTime GetTime(double percentage, DateTime startTime, DateTime endTime)
     {
         TimeSpan diff = endTime - startTime;
         long percentOfTimeAsTicks = (long) (percentage * diff.Ticks);
         return startTime + new TimeSpan(percentOfTimeAsTicks);
     }
