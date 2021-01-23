    DateTime now = DateTime.Now;
    for (DateTime dt = now; dt < now.AddYears(1); dt += TimeSpan.FromMinutes(30))
    {
        DateTime dt2 = dt.ToUniversalTime().ToLocalTime(); // dt2 == dt ?
        if (dt.ToString() != dt2.ToString())
        {
            Console.WriteLine("oops: {0}, {1}", dt, dt2);
        }
    }
