    while ((line = file.ReadLine()) != null)
    {
        bgWorker.RunWorkerAsync(line.ToString());
        //Keep looping til the worker is finished.
        while(bgWorker.IsBusy) 
            Thread.Sleep(10);
    }
