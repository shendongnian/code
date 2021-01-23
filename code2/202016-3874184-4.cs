    public class Worker
    {
      private Thread m_Thread = new Thread(Run);
    
      public event EventHandle<ProgressEventArgs> Progress;
    
      public void Start()
      {
        m_Thread.Start();
      }
    
      private void Run()
      {
        while (true)
        {
          // Do some work.
    
          OnProgress(new ProgressEventArgs(...));
     
          // Do some work.
        }
      }
    
      private void OnProgress(ProgressEventArgs args)
      {
        // Get a copy of the multicast delegate so that we can do the
        // null check and invocation safely. This works because delegates are
        // immutable. Remember to create a memory barrier so that a fresh read
        // of the delegate occurs everytime.
        Thread.MemoryBarrier(); 
        var local = Progress;
        Thread.MemoryBarrier();
        if (local != null)
        {
          local(this, args);
        }
      }
    }
