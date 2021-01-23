        static volatile bool SYNC_IN_PROGRESS; 
        static thread syncPoll; 
        public void StartSync() 
        { 
            SYNC_IN_PROGRESS = false; 
            syncPoll = new Thread(sync);
            syncPoll.Start();
        } 
 
        void sync() 
        { 
            while (true)
            {
                 Debug.WriteLine("Sync?");
                 if (SYNC_IN_PROGRESS) Debug.WriteLine("Syncing..."); 
                 Thread.Sleep(1000);
            }
        } 
