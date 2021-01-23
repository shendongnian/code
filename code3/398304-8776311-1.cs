    switch (unitToRoundDownTo)
    {
        case Unit.Second:
            return new DateTime(old.Year, old.Month, old.Day,
                                old.Hour, old.Minute, old.Second, old.Kind);
        case Unit.Minute:
            return new DateTime(old.Year, old.Month, old.Day,
                                old.Hour, old.Minute, 0, old.Kind);
        case Unit.Hour:
            return new DateTime(old.Year, old.Month, old.Day, old.Hour, 0, 0, old.Kind);
        case Unit.Day:
            return new DateTime(old.Year, old.Month, old.Day, 0, 0, 0, old.Kind);
        case Unit.Month:
            return new DateTime(old.Year, old.Month, 1, 0, 0, 0, old.Kind);
        case Unit.Year:
            return new DateTime(old.Year, 1, 1, 0, 0, 0, old.Kind);
        default:
            throw new ArgumentOutOfRangeException();
    }
