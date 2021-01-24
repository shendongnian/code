    class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(ConvertToLocalDate("1579631400000").ToUniversalTime());
    
                Console.ReadKey();
            }
    
            public static DateTime ConvertToLocalDate(string timeInMilliseconds)
            {
                double timeInTicks = double.Parse(timeInMilliseconds);
                TimeSpan dateTimeSpan = TimeSpan.FromMilliseconds(timeInTicks);
                DateTime dateAfterEpoch = new DateTime(1970, 1, 1) + dateTimeSpan;
                DateTime dateInLocalTimeFormat = dateAfterEpoch.ToLocalTime();
                return dateInLocalTimeFormat;
            }
        }
