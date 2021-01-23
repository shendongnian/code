    public class Example
    {
      private BlockingCollection<WorkItem> m_Queue = new BlockingCollection<WorkItem>();
      public event EventHandler<WorkItemEventArgs> WorkItemCompleted;
    
      public Example()
      {
        var thread = new Thread(
          () =>
          {
            while (true)
            {
              WorkItem item = m_Queue.Take();
              // Add code to process the work item here.
              if (WorkItemCompleted != null)
              {
                 WorkItemCompleted(this, new WorkItemEventArgs(item));
              }
            }
          });
        thread.IsBackground = true;
        thread.Priority = ThreadPriority.BelowNormal;
        thread.Start();
      }
    
      public void Add(WorkItem item)
      {
        m_Queue.Add(item);
      }
    
    }
