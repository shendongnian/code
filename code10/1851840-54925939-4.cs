    public static MonthEventsResponseModel GetEventData(int year, Month month)
    {
        var days = DateTime.DaysInMonth(year, (int)month);
        MonthEventsResponseModel model = new MonthEventsResponseModel();
        model.Events = Enumerable.Range(1, days)
            .Select(day => new
            {
                Day = day,
                Event = new List<Event>()  //<= Instead of new list, Fill Event data with respect to particular day from List or Database Call or API call
            })
            .ToDictionary(x => x.Day, y => y.Event);
        return model;
    }
    
