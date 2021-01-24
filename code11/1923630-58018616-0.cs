        static void Main(string[] args)
        {
            var groupedData = new List<DemoObj>
                {
                    new DemoObj { Amount = 11, Month = 1, Week = 1 },
                    new DemoObj { Amount = 133, Month = 1, Week = 2 },
                    new DemoObj { Amount = 323, Month = 1, Week = 3 },
                    // Needs to add week 4
                    new DemoObj { Amount = 2342, Month = 2, Week = 1 },
                    // Needst to add week 2
                    new DemoObj { Amount = 23433, Month = 2, Week = 3 }
                    // Needs to add etc.. 
                };
            var fullData = AddMissingValues(groupedData);
        }
        private static IEnumerable<DemoObj> AddMissingValues(IEnumerable<DemoObj> valuesFromDb)
        {
            var results = valuesFromDb.ToList();
            var possibleMonths = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var possibleWeeks = new[] { 1, 2, 3, 4 };
            foreach (var possibleMonth in possibleMonths)
            {
                foreach (var possibleWeek in possibleWeeks)
                {
                    if (results.Any(x => x.Month == possibleMonth && x.Week == possibleWeek) == false)
                    {
                        results.Add(new DemoObj { Month = possibleMonth, Week = possibleWeek });
                    }
                }
            }
            return results.OrderBy(x => x.Month).ThenBy(x => x.Week);
        }
        public class DemoObj
        {
            public decimal Amount { get; set; }
            public int Month { get; set; }
            public int Week { get; set; }
        }
