    public static void DoStuff(object objectState)
    {
        DateTime now = DateTime.Now;
        if(now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday)
        {
            // do some stuff
        }
    }
