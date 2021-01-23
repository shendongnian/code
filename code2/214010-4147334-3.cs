    public static class DateTimeExtensions
    {
        public static DateTime SmallDateTimeMinValue(this DateTime sqlDateTime)
        {
            return new DateTime(1900, 01, 01, 00, 00, 00);
        }
        public static DateTime SmallDateTimeMaxValue(this DateTime sqlDateTime)
        {
            return new DateTime(2079, 06, 06, 23, 59, 00);
        }
        
    }
    DateTime date = DateTime.Now;
    Console.WriteLine("Minvalue is {0} ", date.SmallDateTimeMinValue().ToShortDateString());
