    [Flags]
    enum DayMask
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }
    static DayOfWeek FindNextDay(DayMask mask, DayOfWeek currentDay)
    {
        DayOfWeek bestDay = currentDay;
        int bmask = 1;
        for (int checkDay = 0; checkDay < 7; ++checkDay)
        {
            if (((int)mask & bmask) != 0)
            {
                if (checkDay >= (int)currentDay)
                {
                    bestDay = (DayOfWeek)checkDay;
                    break;
                }
                else if (bestDay == currentDay)
                {
                    bestDay = (DayOfWeek)checkDay;
                }
            }
            bmask <<= 1;
        }
        return bestDay;
    }
