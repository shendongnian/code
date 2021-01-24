        class Program
        {
            static void Main(string[] args)
            {
                List<Location> locations = new List<Location>() {
                    new Location() { BlockId = 438001,DistrictId = 438,TownId = 0,UserId = 1077, UserTypeId = 4,VillageId = 238047,ZoneId = 1018 },
                    new Location() { BlockId = 438001,DistrictId = 438,TownId = 0,UserId = 1077,UserTypeId = 4,VillageId = 238048,ZoneId = 1018},
                    new Location() { BlockId = 438002,DistrictId = 438,TownId = 0,UserId = 1077,UserTypeId = 4,VillageId = 238138,ZoneId = 1018 }
                };
                Dictionary<int, List<Location>> dict = locations
                    .GroupBy(x => x.BlockId, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
      
            }
        }
        public class Location
        {
            public int BlockId { get; set; }
            public int DistrictId { get; set; }
            public int TownId { get; set; }
            public int UserId { get; set; }
            public int UserTypeId { get; set; }
            public int VillageId { get; set; }
            public int ZoneId { get; set; }
        }
