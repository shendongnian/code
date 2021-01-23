    public class Cell
    {
      private object m_LockObject = new object();
    
      public object ReadMyState()
      {
        lock (m_LockObject)
        {
          // Return the data here.
        }    
      }
    
      public void ChangeMyState()
      {
        lock (m_LockObject)
        {
          // Make your changes here.
        }    
      }
    }
