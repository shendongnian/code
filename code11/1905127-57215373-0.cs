Dictionary<DateTime, int> example = new Dictionary<DateTime, int>() 
            { 
                {new DateTime(2019,07,01), 1 },
                {new DateTime(2019,07,02), 2 },
                {new DateTime(2019,07,03), 3 }
            };
var HighestKey = example.Keys.Max(); 
