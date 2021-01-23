    DateTime someUtcTime;
    // Max due time to long.MaxValue
    double doubleDueTime = (someUtcTime - DateTime.UtcNow).TotalMilliseconds;
    // Avoid negative numbers
    long dueTime = Math.Max(0L, (long)doubleDueTime);
    _timer.Change(dueTime, System.Threading.Timeout.Infinite);
