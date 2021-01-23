    static void Main(string[] args)
        {
            List<DateTime[]> weeks = new List<DateTime[]>();
            DateTime beginDate = new DateTime(2011, 01, 01);
            DateTime endDate = new DateTime(2012, 01, 01);
            DateTime monday = DateTime.Today;
            DateTime friday = DateTime.Today;
            while (beginDate < endDate)
            {
                beginDate = beginDate.AddDays(1);
                if (beginDate.DayOfWeek == DayOfWeek.Monday)
                {
                    monday = beginDate;
                }
                else if (beginDate.DayOfWeek == DayOfWeek.Friday)
                {
                    friday = beginDate;
                }
                else if (beginDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    weeks.Add(new DateTime[] { monday, friday });
                }
            }
            for (int x = 0; x < weeks.Count; x++)
            {
                Console.WriteLine(weeks[x][0].Date.ToShortDateString() + " - " + weeks[x][1].Date.ToShortDateString());
            }
            Console.ReadLine();
            
        }
