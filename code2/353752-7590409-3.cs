    private System.Threading.Semaphore m_Semaphore = new System.Threading.Semaphore(0, 1);
    void YourCallback(object sender, EventArgs args) 
    {
      if(m_Semaphore.WaitOne(0)) 
      {
        try 
        { 
          // Do the work here... 
        }
        finally { m_Semaphore.Release(); }
      }
    }
