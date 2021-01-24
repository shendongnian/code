        static void Main(string[] args)
        {
            var monday = FirstMondayOfYear(2019);
            var lastDay = new DateTime(2019, 12, 31);
            for (var currentMonday = monday; currentMonday.CompareTo(lastDay) <= 0; currentMonday = currentMonday.AddDays(7))
            {
                Console.WriteLine(currentMonday.ToString("dd/MM/yyyy"));
                //Add it to your list or whatever
            }
            Console.ReadKey();
        }
        public static DateTime FirstMondayOfYear(int year)
        {
            var tmp = new DateTime(year - 1, 12, 30);
            return tmp.AddDays(8-(int)tmp.DayOfWeek);
        }
