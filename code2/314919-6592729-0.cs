     public static void Main()
        {
            //Application.Run(new XmlTreeDisplay());
            int monthdiuff = monthDifference(Convert.ToDateTime("01/04/09"), Convert.ToDateTime("10/27/10"));
            Console.WriteLine(monthdiuff);
            int totalQuater = (monthdiuff / 3) + (monthdiuff%3);
            Console.WriteLine(totalQuater);
            Console.ReadLine();
        }
    
        private static int monthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }
