    public static class TimeSpanExtensions
    {
       private static string ConvertTimeSpanToString (this TimeSpan myTimeSpan)
       {
          return (int) myTimeSpan.TotalHours + ":" + myTimeSpan.Minutes.ToString("00");
       }
    }
