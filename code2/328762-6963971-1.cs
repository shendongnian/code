    public class Example
    {
      private List<object> m_Original;
      private volatile List<object> m_Copy;
    
      public Example()
      {
        m_Original = new List<object>();
        m_Copy = m_Original;
      }
    
      public void Update()
      {
        lock (m_Original)
        {
          // Modify m_Original here.
          
          // Now clone m_Original and replace m_Copy.
          m_Copy = new List<object>(m_Original);
        }
      }
    
      public object Read(int index)
      {
        // It is safe to access m_Copy here since we are treating it as being immutable.
        // m_Copy must be marked as volatile for this to work correctly.
        return m_Copy[index];
      }
    }
