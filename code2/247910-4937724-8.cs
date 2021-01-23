    class AgingWait
    {
     System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
     int maxMilliseconds;
     bool forceExpire;
     public bool Expired
     {
         get { return forceExpire || maxMilliseconds < _watch.ElapsedMilliseconds; }
     }
     public AgingWait(int milli)
     {
         _watch.Start();
         maxMilliseconds = milli;
     }
     public void Expire()
     {
         forceExpire = true;
     }
    }
