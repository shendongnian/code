    protected override void OnStart(string[] args)
            {              
                Thread processor= new Thread(ThreadProc);
                processor.Start();
            }
    
            private void ThreadProc()
            {
                while (true)
                {
                    Thread.Sleep(TimeSpan.FromMinutes(5));
                   
                }
            }
