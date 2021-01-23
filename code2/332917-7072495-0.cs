    for(int i = 0; i < numThreads; i++)
    {
        Thread t = new Thread(()=>
        {
            try
            {
                while(working)
                {
                    file = DownloadSingleFile(blockingFileQueue.Dequeue());
                }
            }
            catch(InterruptException)
            {
                // eat the exception and exit the thread
            }
        });
        t.IsBackground = true;
        t.Start();
    }
