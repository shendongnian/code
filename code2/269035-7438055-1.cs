        bool progressed;
        backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        string[] workerResult = new string[2];
        for (int i = 0; i < 2; ++i) {
            progressed=true;
            
            workerResult[0] = "this string";
            workerResult[1] = "some other string";
            backgroundWorker1.ReportProgress(i, workerResult);
            while (progressed)
            {
               //you can add a thread sleep 
            }
        }
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
             progressed = false;
        }
    
