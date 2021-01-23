    string UniqueID()
    {
        var t = DateTime.UtcNow;
        long dgit = t.Millisecond   * 1000000000L +
                    t.DayOfYear     * 1000000L +
                    t.Hour          * 10000L +
                    t.Minute        * 100L +
                    t.Second;
        return Convert.ToBase64String(BitConverter.GetBytes(dgit).Take(5).ToArray()).TrimEnd('=');
    }
