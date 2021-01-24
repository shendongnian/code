    class Program
    {
        //Simple 'file info' class
        public class FileInfo
        {
            public int Index { get; set; }
            public DateTime StartTime { get; set; }
            public string OtherInfo { get; set; }
        }
        //Set up example data.
        static List<FileInfo> data = new List<FileInfo>()
        {
            new FileInfo{ Index = 0, StartTime = new DateTime(2019,01,01), OtherInfo="Item 0" },
            new FileInfo{ Index = 1, StartTime = new DateTime(2019,01,01), OtherInfo="Item 1" },
            new FileInfo{ Index = 2, StartTime = new DateTime(2019,01,01), OtherInfo="Item 2" },
            new FileInfo{ Index = 3, StartTime = new DateTime(2019,02,01), OtherInfo="Item 3" },
            new FileInfo{ Index = 4, StartTime = new DateTime(2019,02,01), OtherInfo="Item 4" },
            new FileInfo{ Index = 5, StartTime = new DateTime(2019,02,01), OtherInfo="Item 5" },
            new FileInfo{ Index = 6, StartTime = new DateTime(2019,03,01), OtherInfo="Item 6" },
            new FileInfo{ Index = 7, StartTime = new DateTime(2019,04,01), OtherInfo="Item 7" }
        };
        static void Main(string[] args)
        {
            //First GroupBy what you want to group by.
            var groupedList = data.GroupBy(x => x.StartTime);
            //This gives a list with the number of distinct group items.
            foreach (var groupEntry in groupedList)
            {
                //groupEntry is an IGrouping, which contains 'key' as the group key
                //(a DateTime in this case, StartTime in the source list)
                Console.WriteLine($"Items in Group : {groupEntry.Key}");
                //each item is itself an IEnumerable of the items in that group
                foreach (var groupItem in groupEntry.OrderBy(x=>x.Index))
                {
                    Console.WriteLine($"  - Index:{groupItem.Index}; OtherInfo = {groupItem.OtherInfo}");
                }
            }
        }
    }
