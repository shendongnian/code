    private static DateTime _jsDateBoundary = new DateTime(1970, 1, 1, 0, 0, 0);
    public Int64 GetCountdownMilliseconds()
    {
      DateTime countdownDeadline = DateTime.Now.AddDays(1).ToUniversalTime();
      return (Int64)countdownDeadline.Subtract(_jsDateBoundary).TotalMilliseconds;
    }
