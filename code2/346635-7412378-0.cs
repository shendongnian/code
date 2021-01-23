        static void Main(string[] args)
        {
            List<Festival> dates =new List<Festival>();
            Festival chirstmas = new Festival() 
            { 
                Name = "Christmas", 
                startDate = new DateTime(2011, 12, 25), 
                endDate = new DateTime(2011, 12, 31) 
            };
            AddFestival(dates, chirstmas);
            AddFestival(dates, new Festival()
            {
                Name = "NewYear",
                startDate = new DateTime(2011, 12, 31),
                endDate = new DateTime(2012, 1, 01)
            });
            Console.ReadLine();
        }
        static void AddFestival(List<Festival> dates, Festival newFestival)
        {
            if (ValidDates(newFestival) &&
                !NameExists(dates, newFestival) &&
                !NonHoliday(dates, newFestival) )
            {
                dates.Add(newFestival);
            }
        }
        private static bool NonHoliday(List<Festival> dates, Festival newFestival)
        {
            return dates.Exists((date) => 
                newFestival.startDate >= date.startDate && newFestival.startDate <= date.endDate ||
                newFestival.endDate >= date.startDate && newFestival.endDate <= date.endDate);
        }
        private static bool NameExists(List<Festival> dates, Festival newFestival)
        {
            return dates != null && 
                dates.Count() > 0  && 
                dates.FirstOrDefault((dt) => dt.Name == newFestival.Name) != null;
        }
        private static bool ValidDates(Festival newFestival)
        {
            return newFestival.endDate >= newFestival.startDate;
        }
        class Festival
        {
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public string Name { get; set; }
        }
