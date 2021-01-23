    DateTime currentTime = Datetime.Now;
    DateTime aBitEarlier = currentTime.AddHours(-5).AddMinutes(-4);
    
    if (currentTime.Date == aBitEarlier.Date)
    {
        ...
    }
