    public string GenerateOrderID()
    {
        return String.Format("{0:yyyyMMddHHmmss}{1}",
                             DateTime.Now,
                             Interlocked.Increment(ref orderCount));
    }
