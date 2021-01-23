    private readonly Dictionary<WaitHandle, Action> actions = new Dictionary<WaitHandle, Action>();
        private readonly List<WaitHandle> handles = new List<WaitHandle>();
        private readonly List<WaitHandle> triggeredHandles = new List<WaitHandle>();
    
    // thread 1
        public void CheckLoop()
        {
            do
            {
                WaitHandle[] waitHandles = handles.ToArray();
                int index = WaitHandle.WaitAny(waitHandles);
    
                if (index >= 0)
                {
                    lock (triggeredHandles)
                    {
                       triggeredHandles.Add(waitHandles[index]);
                    }
    
                }            
            } while (true);
        }
    
    // thread 2
    public void RunLoop()
        {
            do
            {
                lock(triggeredHandles)
                {
                    foreach (var th in triggeredHandles) {
    
                       Action action;
                       lock (syncRoot)
                       {
                           action = actions[th];
                       }
    
                       action();                   
                    }
                    triggeredHandles.Clear();
                }
                Thread.Sleep(5000);
            } while (true);
        }
