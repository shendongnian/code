    public class Example
    {
      ManualResetEvent m_Event = new ManualResetEvent(false);
    
      void ThreadA()
      {
        lock (this)
        {
          m_Event.WaitOne();
        }
      }
    
      void ThreadB()
      {
        lock (this)
        {
          m_Event.Set();
        }
      }
    }
