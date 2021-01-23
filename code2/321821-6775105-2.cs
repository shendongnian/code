    var latestExpirationDate = myCollection
        .Where(item => item.ExpirationDate.HasValue)
        .OrderByDescending(item => item.ExpirationDate)
        .Select(item => item.ExpirationDate) // DateTime?
        .FirstOrDefault();
    if (latestExpirationDate != null)
    {
        // do something with the value stored in latestExpirationDate
    }
