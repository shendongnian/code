    var options = new QueryOption[]
    {
        new QueryOption("startDateTime", DateTime.UtcNow.ToString("o")),
        new QueryOption("endDateTime", DateTime.UtcNow.AddDays(1).ToString("o")),
    };
    
    var events = await graphServiceClient
        .Me
        .CalendarView
        .Request(options)
        .GetAsync();
