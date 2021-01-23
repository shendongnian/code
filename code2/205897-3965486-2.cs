    class Program
    {
        static void Main(string[] args)
        {
            var sourceItems = new[] {
                new LogEntry {ID=1   ,UserName="foo      ", TimeStamp= new DateTime(2010 ,1,01),Details="Account created ",}    ,
                new LogEntry {ID=2   ,UserName="zip      ", TimeStamp= new DateTime(2010 ,2,02),Details="Account created ",}    ,
                new LogEntry {ID=3   ,UserName="bar      ", TimeStamp= new DateTime(2010 ,2,02),Details="Account created ",}    ,
                new LogEntry {ID=4   ,UserName="sandwich ", TimeStamp= new DateTime(2010 ,3,03),Details="Account created ",}    ,
                new LogEntry {ID=5   ,UserName="bar      ", TimeStamp= new DateTime(2010 ,5,05),Details="Stole food      ",}    ,
                new LogEntry {ID=6   ,UserName="foo      ", TimeStamp= new DateTime(2010 ,5,05),Details="Can't find food ",}    ,
                new LogEntry {ID=7   ,UserName="sandwich ", TimeStamp= new DateTime(2010 ,8,08),Details="Donated food    ",}    ,
                new LogEntry {ID=8   ,UserName="sandwich ", TimeStamp= new DateTime(2010 ,9,09),Details="Ate more food   ",}    ,
                new LogEntry {ID=9   ,UserName="foo      ", TimeStamp= new DateTime(2010 ,9,09),Details="Ate food        ",}    ,
                new LogEntry {ID=10  ,UserName="bar      ", TimeStamp= new DateTime(2010,11,11),Details="Can't find food ",}    ,
            };
            var results = sourceItems
                .OrderByDescending(item => item.TimeStamp)
                .GroupBy(item => item.UserName)
                .Select(grp => grp.First())
                .OrderBy(item=> item.ID)
                .ToArray();
            foreach (var item in results)
            {
                Console.WriteLine("{0} {1} {2} {3}",
                    item.ID, item.UserName, item.TimeStamp, item.Details);
            }
            Console.ReadKey();
        }
    }
    public class LogEntry
    {
        public int ID;
        public string UserName;
        public DateTime TimeStamp;
        public string Details;
    }
