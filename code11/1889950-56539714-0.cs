    class Program
    {
        static void Main(string[] args)
        {
            var delta = 3600;
            List<TimeZone> TimeZones = new List<TimeZone>()
            {
                new TimeZone() {Id = 1, Name = "America/Tortola", UtcOffset = -14400},
                new TimeZone() {Id = 2, Name = "Asia/Kathmandu", UtcOffset = 20700},
                new TimeZone() {Id = 3, Name = "Asia/Kolkata", UtcOffset = 19800},
                new TimeZone() {Id = 4, Name = "Africa/Tunis", UtcOffset = 3600},
                new TimeZone() {Id = 5, Name = "Africa/Windhoek", UtcOffset = 7200},
                new TimeZone() {Id = 6, Name = "Europe/Simferopol", UtcOffset = 10800},
            };
            List<Int32> offsets = new List<Int32>()
            {
                3600, -10800, -14400
            };
            var matchedList = TimeZones.Where(x => offsets.Any(y => x.UtcOffset <= (y + delta))).ToList();
        }
    }
    public class TimeZone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UtcOffset { get; set; }
    }
