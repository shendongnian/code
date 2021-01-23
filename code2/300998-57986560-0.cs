    public void Sleep(double msec)
    {
       for (var since = DateTime.Now; (DateTime.Now - since).TotalMilliseconds < msec;)
          Thread.Sleep(TimeSpan.FromTicks(10));
    }
