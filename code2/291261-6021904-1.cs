    public void Run()
    {
      while (true)
      {
        Event task = m_Queue.Take();
        if (task == null)
        {
          return;
        }
        task.DoTask();
      }
    }
