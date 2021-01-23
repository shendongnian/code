    void ItemClicked(...) 
    {
        lock (WorkQueue)
        {
            QueueNewClickItem(...);
            m_workToDo.Set();
        }
    }
    void WorkerThread(...)
    {
        while (!threadShouldEnd)
        {
            if (m_workToDo.WaitOne())
            {
               lock (WorkQueue)
               {
                   CopyAllPendingWorkItemsToListInThread();
                   ClearWorkQueue();
                   m_workToDo.Reset();
               }
               while (!AllLocalItemsProcessed)
               {
                   ProcessNextWorkItem();
               }
            }
         }
     }
