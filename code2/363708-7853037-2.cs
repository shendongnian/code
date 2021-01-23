    class TestableScheduler : TaskScheduler {
      private Queue<Task> m_taskQueue = new Queue<Task>();
    
      protected override IEnumerable<Task> GetScheduledTasks() {
        return m_taskQueue;
      }
    
      protected override void QueueTask(Task task) {
        m_taskQueue.Enqueue(task);
      }
    
      protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) {
        task.RunSynchronously();
      }
    
      public void RunAll() {
        while (m_taskQueue.Count > 0) {
          m_taskQueue.Dequeue().RunSynchronously();
        }
      }
    }
