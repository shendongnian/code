            DateTime sinceExec = DateTime.Now;
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += (bgSender, bgArgs) =>
            {
                sinceExec = DateTime.Now;
                Debug.WriteLine("Test!");
                Thread.Sleep(5000);
            };
            bgWorker.RunWorkerCompleted += (bgSender, bgArgs) =>
            {
                // it didn't take 10000 milliseconds
                if ((sinceExec - DateTime.Now).Milliseconds < 10000) 
                {
                    //Calculate time to wait
                    TimeSpan timeToWait = new TimeSpan((DateTime.Now.Ticks - sinceExec.Ticks) / 10000);
                    // wait that amount of time
                    Thread.Sleep(timeToWait);
                    //Re-execute the worker
                    bgWorker.RunWorkerAsync();
                }
            };
            bgWorker.RunWorkerAsync();
