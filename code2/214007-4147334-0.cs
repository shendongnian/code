    public static class DateTimeExtensions
    {
        public static DateTime MinValue(this DateTime sqlDateTime)
        {
            return new DateTime(1900, 01, 01);
        }
        public static DateTime MaxValue(this DateTime sqlDateTime)
        {
            return new DateTime(2079, 06, 06);
        }
        
    }
    DateTime date = DateTime.Now;
    Console.WriteLine("Minvalue is {0} ", date.MinValue().ToShortDateString());
