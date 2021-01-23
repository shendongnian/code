        static void Start()
        {
            // Start MUST be called before you can tick the tree.
            Logic.Start(null);
            // do work to spool up a thread, or whatever to call Tick();
        }
        
        private static void Tick()
        {
            try
            {             
                Logic.Tick(null);
                // If the last status wasn't running, stop the tree, and restart it.
                if (Logic.LastStatus != RunStatus.Running)
                {
                    Logic.Stop(null);
                    Logic.Start(null);
                }
            }
            catch (Exception e)
            {
                // Restart on any exception.
                Logging.WriteException(e);
                Logic.Stop(null);
                Logic.Start(null);
                throw;
            }
        }
