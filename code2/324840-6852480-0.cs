    class WorkManager {
        void DoWord {
            WorkTask task = GetNextWorkTask();
            PerformWork(task);
            task.Complete();
        }
        
        WorkTask GetNextWorkTask() { ... }
        
        void PerformWork(WorkTask task) { ... }
    }
    
    virtual class WorkTask {
        virtual void Complete;
    }
    
    class WorkTask1 : WorkTask {
        void Complete {
            print("Job 1 done.");
        }
    }
