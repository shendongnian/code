        public class Inventory 
        {
            public Inventory()
            {
               MonthList = new List<Month>();
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public List<Month> MonthList {get; set;} 
        }
        public class Month
        {
            public Month()
            {
               DayList = new List<Day>();
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public List<Day> DayList {get; set;} 
        }
        List<Inventory> inventoryList = new List<Inventory>()
        {
           new Inventory()
           { 
               Id = 1,
               Name = "test", 
               Description = "desc.",
               MonthList = new List<Month>()
               {
                  Id = 1, 
                  Name = "test", 
                  Description = "desc.",
                  DayList = new List<Day>(){...}
               }
            }
         }
