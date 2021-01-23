    public bool HasExpired()
    {
        string expires = ReadDateFromDataBase(); // output example: 21/10/2011 21:31:00
        DateTime Expires = DateTime.Parse(expires);
        return DateTime.Now.CompareTo(Expires.Add(new TimeSpan(2, 0, 0))) > 0;
    }
