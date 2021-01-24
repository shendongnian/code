    public static class Model
        {
            public static List<Safety> GetData()
            {
                return new List<Safety>()
                {
                    new Safety() { ID = 1, Name = "First", Quarter = 1, SafetyScore = 1, Year = 2001 },
                    new Safety() { ID = 2, Name = "Second", Quarter = 2, SafetyScore = 1, Year = 2001 },
                    new Safety() { ID = 3, Name = "Third", Quarter = 3, SafetyScore = 1, Year = 2001 },
                    new Safety() { ID = 4, Name = "Fourth", Quarter = 4, SafetyScore = 1, Year = 2001 },
                    new Safety() { ID = 5, Name = "First", Quarter = 1, SafetyScore = 1, Year = 2002 },
                    new Safety() { ID = 6, Name = "Second", Quarter = 2, SafetyScore = 1, Year = 2002 },
                    new Safety() { ID = 7, Name = "Third", Quarter = 3, SafetyScore = 1, Year = 2002 },
                    new Safety() { ID = 8, Name = "Fourth", Quarter = 4, SafetyScore = 1, Year = 2002 },
                };
            }
        }
