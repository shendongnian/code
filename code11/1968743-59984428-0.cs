    public bool IsInsideTimeframe(DateTime firstStart, DateTime firstEnd, DateTime secondStart, DateTime secondEnd)
    {
        bool isInside;
    
        if (firstStart.Ticks >= secondStart.Ticks && firstEnd.Ticks <= secondEnd.Ticks)
            isInside = true;
        else
            isInside = false;
    
        return isInside;
    }
