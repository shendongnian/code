    public class MyClass
    {
      private CountdownEvent m_Finished = new CountdownEvent(0);
        
      public void Start()
      {
        m_Finished.AddCount(); // Increment to indicate that this thread is active.
        
        for (int i = 0; i < NUMBER_OF_THREADS; i++)
        {
          m_Finished.AddCount(); // Increment to indicate another active thread.
          new Thread(Method_01).Start();
        }
        
        for (int i = 0; i < NUMBER_OF_THREADS; i++)
        {
          m_Finished.AddCount(); // Increment to indicate another active thread.
          new Thread(Method_02).Start();
        }
        new Thread(Method_03).Start();
        
        m_Finished.Signal(); // Signal to indicate that this thread is done.
      }
    
      private void Method_01()
      {
        try
        {
          // Add your logic here.
        }
        finally
        {
          m_Finished.Signal(); // Signal to indicate that this thread is done.
        }
      }
    
      private void Method_02()
      {
        try
        {
          // Add your logic here.
        }
        finally
        {
          m_Finished.Signal(); // Signal to indicate that this thread is done.
        }
      }
    
      private void Method_03()
      {
        m_Finished.Wait(); // Wait for all signals.
        // Add your logic here.
      }
    }
