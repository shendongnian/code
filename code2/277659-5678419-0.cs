    DateTime lastCheck = DateTime.Now;
    private void update()
    {
        // DateTime.Subtract returns a TimeSpan
        int elapsed = DateTime.Now.Subtract(lastCheck).Milliseconds;
        if (elapsed < 100)
        {
            Console.WriteLine("!skip update " + elapsed.ToString());
            return;
        } else
        {
            Console.WriteLine("!update");
            lastCheck = DateTime.Now;
        }
        // do work here
    }
