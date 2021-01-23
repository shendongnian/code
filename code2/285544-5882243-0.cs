    if (logType == LogType.Disk)
    {
        query = query.OfType<DiskLog>(); // not sure if you need conversion here
    } 
    else if (logType == LogType.Network)
    {
        query = query.OfType<NetworkLog>(); // not sure if you need conversion here
    }
    query = query.Where(x => x.Computer.User.UserKey == userKey);
    if (computerId != 0)
       query = query.Where( x => x.Computer.Id == computerId);
    // .. and so on
    query = query.OrderByDescending(x => x.Id).Skip(nSkip).Take(nTake);
    return query.ToList(); // do database call, materialize the data and return;
