    private static Dictionary<DayOfWeek, List<DaysOfWeek>> CreateMaps()
    {
        var maps = new Dictionary<DayOfWeek, List<DaysOfWeek>>();
    
        var daysOfWeek = new List<DaysOfWeek>(7)
        {
            DaysOfWeek.Sunday, 
            DaysOfWeek.Monday, 
            DaysOfWeek.Tuesday, 
            DaysOfWeek.Wednesday, 
            DaysOfWeek.Thursday, 
            DaysOfWeek.Friday, 
            DaysOfWeek.Saturday 
        };
    
        foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
        {
            var map = new List<DaysOfWeek>(7);
    
            for (int i = (int)dayOfWeek; i < 7; i++)
            {
                map.Add(daysOfWeek[i]);
            }
    
            for (int i = 0; i < (int)dayOfWeek; i++)
            {
                map.Add(daysOfWeek[i]);
            }
    
            maps.Add(dayOfWeek, map);
        }
    
        return maps;
    }
