    // Shared
    AutoResetEvent m_moveHit = new AutoResetEvent(false);
    
    // Thread 1 
    void MoveHit(Position position) {
      if (position == thePositionDesired) {
        m_moveHit.Set();
      }
    }
    
    // Thread 2
    void Go() {
      // Wait until the move happens 
      m_moveHit.WaitOne();
    
      // Won't get here until it happens
    }
