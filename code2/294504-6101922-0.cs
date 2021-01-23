    TimeSpan Intersection(DateTime start, DateTime end, Movement movement)
    {
        DateTime t1 = start > movement.StartTime ? start : movement.StartTime;
        DateTime t2 = end < movement.EndTime ? end  : movemnt.EndTime;
        return t1 < t2 ? t2 - t1 : TimeSpan.Empty;
    }
