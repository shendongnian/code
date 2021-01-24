    DateTime fromTimeString(string time)
    {
        var p = time.Split(':');
        int sec = p.Length == 3 ? Convert.ToInt16(p[2]) : 0;
        TimeSpan t = new TimeSpan(Convert.ToInt16(p[0]), Convert.ToInt16(p[1]), sec);
        return DateTime.Today.Add(t);
    }
