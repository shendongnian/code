        static void Main(string[] args)
        {
            List<DateTime> allDates = new List<DateTime>();
            DateTime startDate = Convert.ToDateTime("2018-03-03");
            DateTime endDate = Convert.ToDateTime("2018-03-15");
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                allDates.Add(date);
                Console.WriteLine(date);
                
                Console.WriteLine(string.Join(",", allDates));
            }
        }
