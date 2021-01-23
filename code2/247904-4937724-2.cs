    class AgingWait
    {
     System.Diagnostics.Stopwatch _watch;
     int maxMilliseconds;
     bool forceExpire;
     public bool Expired
     {
         get { return forceExpire || maxMilliseconds > _watch.ElapsedMilliseconds; }
     }
     public AgingWait(int milli)
     {
         _watch.Start();
     }
     public void Expire()
     {
         forceExpire = true;
     }
    }
