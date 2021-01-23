    static NormallyOpenTimedLatch LatchThis = new NormallyOpenTimedLatch(t2);
    static NormallyOpenTimedLatch LatchThat = new NormallyOpenTimedLatch(t1);
    
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
