    DateTime RoundCurrentToNextFiveMinutes()
    {
        DateTime now = DateTime.UtcNow,
            result = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
        return result.AddMinutes(((now.Minute / 5) + 1) * 5);
    }
