    public class Dates
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
 
            static void Main(string[] args)
        {
            var ourList = new List<Dates>();
            ourList.Add(new Dates {EndDate = DateTime.MinValue, StartDate = new DateTime(2019, 07, 28, 22, 35, 5,
                new CultureInfo("en-US", false).Calendar)
            });
            ourList.Add(new Dates {EndDate = new DateTime(2019, 07, 28, 23, 35, 5, new CultureInfo("en-US", false).Calendar), StartDate = new DateTime(2019, 07, 29, 22, 35, 5,
                new CultureInfo("en-US", false).Calendar)
            });
            ourList.Add(new Dates
            {
                EndDate = new DateTime(2019, 08, 28, 23, 35, 5, new CultureInfo("en-US", false).Calendar),
                StartDate = new DateTime(2019, 07, 29, 22, 35, 5,
    new CultureInfo("en-US", false).Calendar)
            });
            ourList.OrderBy(zx => zx.EndDate);
            var listOfWrongDates = ourList.Where(zy => zy.StartDate < DateTime.Now &&
                ourList.IndexOf(zy) - 1 >= 0 ? ourList.ElementAt((ourList.IndexOf(zy) - 1)).EndDate > DateTime.Now : false);
            Console.WriteLine("Hello World!");
        }
