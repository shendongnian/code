        bool progressed;
        backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
       
        for (int i = 0; i < 2; ++i) {
            progressed=true;
            string[] workerResult = new string[2];
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
    
