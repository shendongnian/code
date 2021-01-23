         static void Main(string[] args)
        {
            // allFestivals holds all the festival list 
            // allFestivals values may come from some other data source like database
            List<Festival> allFestivals =new List<Festival>();
            // Simulate by inserting Christmas 
            Festival chirstmas = new Festival() 
            { 
                Name = "Christmas", 
                startDate = new DateTime(2011, 12, 25), 
                endDate = new DateTime(2011, 12, 31) 
            };
            AddFestival(allFestivals, chirstmas);
            // NewYear will not be inserted since 31-12-2011 is already 
            // marked as holiday by Christmas
            AddFestival(allFestivals, new Festival()
            {
                Name = "NewYear",
                startDate = new DateTime(2011, 12, 31),
                endDate = new DateTime(2012, 1, 01)
            });
            Console.ReadLine();
        }
        /// <summary>
        /// Add new festival to the list of festivals
        /// </summary>
        /// <param name="allFestivals"></param>
        /// <param name="newFestival"></param>
        static void AddFestival(List<Festival> allFestivals, Festival newFestival)
        {
            // If newFestival meets all the criteria only then add to the list
            if (ValidDates(newFestival) &&
                !NameExists(allFestivals, newFestival) &&
                !NonHoliday(allFestivals, newFestival) )
            {
                // allFestivals values may be strored into database
                allFestivals.Add(newFestival);
            }
        }
        /// <summary>
        /// Check if the newFestival startDate or endDate falls within any of the already
        /// existing festival start and end date
        /// </summary>
        /// <param name="dates"></param>
        /// <param name="newFestival"></param>
        /// <returns></returns>
        private static bool NonHoliday(List<Festival> dates, Festival newFestival)
        {
            return dates.Exists((date) => 
                newFestival.startDate >= date.startDate && newFestival.startDate <= date.endDate ||
                newFestival.endDate >= date.startDate && newFestival.endDate <= date.endDate);
        }
        /// <summary>
        /// If the festival name already exists, returns true else false
        /// </summary>
        /// <param name="dates"></param>
        /// <param name="newFestival"></param>
        /// <returns></returns>
        private static bool NameExists(List<Festival> dates, Festival newFestival)
        {
            return dates != null && 
                dates.Count() > 0  && 
                dates.FirstOrDefault((dt) => dt.Name == newFestival.Name) != null;
        }
        /// <summary>
        /// Validate if end date is greater than or equal to start date
        /// </summary>
        /// <param name="newFestival"></param>
        /// <returns></returns>
        private static bool ValidDates(Festival newFestival)
        {
            return newFestival.endDate >= newFestival.startDate;
        }
        // Data structure represenging festival details
        class Festival
        {
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public string Name { get; set; }
        }
