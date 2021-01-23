    public class Example
    {
      private readonly List<object> m_Official;
      private volatile List<object> m_Readonly;
    
      public Example()
      {
        m_Official = new List<object>();
        m_Readonly = m_Official;
      }
    
      public void Update()
      {
        lock (m_Official)
        {
          // Modify the official copy here.
          m_Official.Add(...);
          m_Official.Remove(...);
          
          // Now clone the official copy.
          var clone = new List<object>(m_Official);
          // And finally swap out the read-only copy reference.
          m_Readonly = clone;
        }
      }
    
      public object Read(int index)
      {
        // It is safe to access the read-only copy here because it is immutable.
        // m_Readonly must be marked as volatile for this to work correctly.
        return m_Readonly[index];
      }
    }
