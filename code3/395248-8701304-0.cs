        static void Main(string[] args)
        {
            Console.WriteLine(GetDifferenceDate(new DateTime(2011, 11, 25, 10, 30, 2), 
                new DateTime(2012, 1, 2, 6, 3, 5)));
        }
        static string GetDifferenceDate(DateTime date1, DateTime date2)
        {
            if (DateTime.Compare(date1, date2) >= 0)
            {
                TimeSpan ts = date1.Subtract(date2);
                return string.Format("{0} days, {1} hours, {2} minutes, {3} seconds", 
                    ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
            }
            else
                return "Not valid";
        }
