    private event SynchronizatonEventHandler m_OnSyncFinished;
    public event SynchronizatonEventHandler OnSyncFinished
    {
      add
      {
        // Custom code could be added here...
        m_OnSyncFinished += value;
      }
      remove
      {
        // Custom code could be added here...
        m_OnSyncFinished -= value;
      }
    }
