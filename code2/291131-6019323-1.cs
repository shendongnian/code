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
        bool threadShouldEnd = false;
        while (!threadShouldEnd)
        {
            if (WaitHandle.WaitAny(m_workToDo, m_endThread) == 0)
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
            else
            {
                threadShouldEnd = true;
            }
         }
     }
