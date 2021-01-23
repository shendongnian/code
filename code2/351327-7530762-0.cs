    static TimedLatch LatchThis = new TimedLatch(t2);
    static TimedLatch LatchThat = new TimedLatch(t1);
    
    static void DoThis()
    {
      LatchThis.Wait();  // Wait for it open.
    
      DoThisStuff();
    
      LatchThat.Close();
    }
    
    static void DoThat()
    {
      LatchThat.Wait(); // Wait for it open.
    
      DoThatStuff();
    
      LatchThis.Close();
    }
