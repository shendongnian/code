    public void IncrementTime(int serial, string errorCode)
    {
        _memObjects.Where(x => x.Serial == serial && x.errorCode == errorCode)
            .ToList()
            .ForEach(x => x.ModifiedAt = x.ModifiedAt.Add(
                            new TimeSpan(0, 0,
                                 _memObjects.Count(x =>  x.Serial == serial && x.errorCode == errorCode)
                            )
            );
    }
