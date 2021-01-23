    public static void PingRange(IPRange range)
    {            
        var finished = new CountdownEvent(1);
        foreach (IPAddress ip in range.GetAllIP())
        {
            finished.AddCount(); // Indicate that a new ping is pending
            var pingSender = new Ping();
            pingSender.PingCompleted +=
              (sender, e) =>
              {
                finished.Signal(); // Indicate that this ping is complete
              };
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            PingOptions options = new PingOptions(64, true);
            pingSender.SendAsync(ip, 4000, buffer, options, waiter);
        }
        finished.Signal(); // Indicate that all pings have been submitted
        finished.Wait(); // Wait for all pings to complete
    }
