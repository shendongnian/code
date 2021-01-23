    public static class DateTimeExtensions
    {
       public static string GetMonthName(this DateTime dateTime)
       {
           // add using System.Globalization;
           return DateTimeFormatInfo.GetMonthName(dateTime.Month);
       }
       public static Months GetMonth(this DateTime dateTime)
       {          
             return (Months)dateTime.GetMonthName();          
       }
    }
