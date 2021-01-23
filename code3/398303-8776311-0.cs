    switch (unitToRoundDownTo)
    {
        case Unit.Second:
            return new DateTime(old.Year, old.Month, old.Day,
                                old.Hour, old.Minute, old.Second);
        case Unit.Minute:
            return new DateTime(old.Year, old.Month, old.Day,
                                old.Hour, old.Minute, 0);
        case Unit.Hour:
            return new DateTime(old.Year, old.Month, old.Day, old.Hour, 0, 0);
        case Unit.Day:
            return new DateTime(old.Year, old.Month, old.Day, 0, 0, 0);
        case Unit.Month:
            return new DateTime(old.Year, old.Month, 1, 0, 0, 0);
        case Unit.Year:
            return new DateTime(old.Year, 1, 1, 0, 0);
        default:
            throw new ArgumentOutOfRangeException();
    }
