    public bool HasExpired(DateTime now)
    {
        string expires = ReadDateFromDataBase(); // output example: 21/10/2011 21:31:00
        DateTime Expires = DateTime.Parse(expires);
        return now.CompareTo(Expires.Add(new TimeSpan(2, 0, 0))) > 0;
    }
