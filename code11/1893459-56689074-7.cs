    void Work(IProgress<string> progress)
    {
        for(int i=0;i<1000000;i++)
        {
            //Do something CPU intensive
            //Report every 1000 items
            if(i%1000==0)
            {
                progress.Report($"{i} out of 1000000");
            }
        }
        //This tells the loader to close.
        progress.Report("");
    }
