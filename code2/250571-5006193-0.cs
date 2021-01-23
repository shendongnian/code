    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            var date1 = new DateTime(2010, 10, 12, 12, 00, 00);
            var date2 = new DateTime(2010, 10, 14, 15, 00, 00);
            var hr1 = ((date1.Hour > 9) && (date1.Hour < 17)) ? 17 - date1.Hour : 0;
            var hr2 = ((date2.Hour > 9) && (date2.Hour < 17)) ? 17 - date2.Hour : 0;
            var middleHours = ((date2.Date -  date1.Date).Days -1) * 8 ;
            Console.WriteLine(hr1+hr2+ middleHours);
            Console.ReadKey();
        }
    }
