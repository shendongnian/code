    public class Worker
    {
      private Thread m_Thread = new Thread(Run);
    
      public event EventHandler<ProgressEventArgs> Progress;
    
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
        // of the delegate occurs everytime. This is done via a simple lock below.
        EventHandler<ProgressEventArgs> local;
        lock (this)
        {
          var local = Progress;
        }
        if (local != null)
        {
          local(this, args);
        }
      }
    }
