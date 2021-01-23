    public static class DateTimeHelper
    {
        public static DateTime Time(this string time)
        {
            DateTime theTime = DateTime.Parse(time);
            return theTime;
        }
    }
    ...
    
       if (DateTime.Now < "8:00 AM".Time() && DateTime.Now > "5:00 PM".Time())
       {
            // do something
       }
