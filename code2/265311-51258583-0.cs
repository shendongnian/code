    using System;
    namespace DemoApp.App
    {
    public class TestClassDate
    {
        public static DateTime GetDate(string string_date)
        {
            DateTime dateValue;
            if (DateTime.TryParse(string_date, out dateValue))
                Console.WriteLine("Converted '{0}' to {1}.", string_date, dateValue);
            else
                Console.WriteLine("Unable to convert '{0}' to a date.", string_date);
            return dateValue;
        }
        public static void Main()
        {
            string inString = "05/01/2009 06:32:00";
            GetDate(inString);
        }
    }
    }
    /**
     * Output:
     * Converted '05/01/2009 06:32:00' to 5/1/2009 6:32:00 AM.
     * */
