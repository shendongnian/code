    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            DateTime? myTime = new DateTime(1970, 1, 1, 0, 0, 1);
    
            Console.Write(myTime.Value.ToUnixTimeInMs().ToString());
            Console.Read();
        }
    }
    
    public static class DateTimeExtensions
    {
        private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1);
    
        public static double ToUnixTimeInMs(this DateTime dateTime)
        {
            return dateTime.Subtract(DateTimeExtensions.unixEpoch).TotalMilliseconds;
        }
    }
