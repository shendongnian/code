    void ThreadProc ()
    {
        //simulate work
        for ( int i = 0; i < 100000; ++i )
        {
            Thread.Sleep( 1 ); // this should allow the form to breath a little :)
            int total = i / 1000;
            backgroundWorker1.ReportProgress( total );
        }
    }
