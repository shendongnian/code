            ThreadPool.QueueUserWorkItem((state) =>
                                             { 
                                                 currentJob.ProcessJob();
                                                 _qLock.EnterWriteLock();
                                                 try
                                                 {
                                                     _jobQueue.Enqueue(currentJob);
                                                 }
                                                 finally
                                                 {
                                                     _qLock.ExitWriteLock();
                                                 } 
                                             
                                             }
                );
