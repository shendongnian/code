    public static class DateTimeExtensions
    {
       public static string GetMonth(this DateTime dateTime)
       {
           if (dateTime.Month == 1) return "January";
       }
       public static Months GetMonthName(this DateTime dateTime)
       {          
             // add using System.Globalization;
             return (Months)DateTimeFormatInfo.GetMonthName(dateTime.Month);          
       }
    }
