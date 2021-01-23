               class DatabaseUpdater
    { 
    // Declare the background worker and WaitForm at Class Level
    static BackgroundWorker bw;
    public static Form WaitForm;
    public static void DelegateWorkStuff()
    {
        // Set up the background process and show WaitForm in here        
        
        bw = new BackgroundWorker();
        bw.WorkerReportsProgress = true;
        WaitForm = new WaitForm();
        WaitForm.Show();
        bw.DoWork += bw_DoWork;
        bw.ProgressChanged += bw_ProgressChanged;
        bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        bw.RunWorkerAsync();
     }
       static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //Run the lenghty code/processes in here
        }
       static void bw_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
       {
            //Close the Waitform thus
            WaitForm.Close();
       }
