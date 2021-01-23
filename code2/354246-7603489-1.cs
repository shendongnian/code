    DayOfWeekEnum MaskValue; // set to whatever your mask is
    int DayOfWeek; // the day you want to find the next match for
    int checkMask = 1;
    int bestDay = -1; // no day found
    for (int checkDay = 0; checkDay < 7; ++checkDay)
    {
        if ((MaskValue && checkMask) != 0)
        {
            if (checkDay >= DayOfWeek)
            {
                bestDay = checkDay;
                break;
            }
            else if (bestDay == -1)
            {
                bestDay = checkDay;
            }
        }
        checkMask <<= 1;
    }
