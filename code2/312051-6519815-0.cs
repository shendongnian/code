    DateTime backupStart = Convert.ToDateTime("20:00:00");
    DateTime backupEnd = Convert.ToDateTime("22:00:00");
    DateTime now = DateTime.Now;
    while (true)
    {
        // If its backup time then sleep for 2 hours, 0 min and 0 seconds
        if (now > backupStart && now < backupEnd)
        {
            System.Threading.Thread.Sleep(new TimeSpan(2, 0, 0));
            now = DateTime.Now; // So we dont sleep again later
        }
 
        try
        {
            // Try db connect
            // Break if successful
            break;
        }
        catch (Exception ex)
        {
            // Wait 30 seconds then loop then try again
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 30));
        }
    }
