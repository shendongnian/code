        var _CycleType = new List<CycleType>
        {
            new CycleType { Type = "Leisure Cycle Type A" },
            new CycleType { Type = "Mountain Bike Type A" },
            new CycleType { Type = "Racer" },
            new CycleType { Type = "Leisure Cycle Type B" },
            new CycleType { Type = "Mountain Bike Type B" }                
        }.ForEach(c => context.CycleType.Add(c)); 
