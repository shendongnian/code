    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        string from = sender as string;
    
        switch case (string)
        {
            case "ab" : 
                       // process
                       break;
            case "b" : 
                       // process
                       break;
            case "c" : 
                       // process
                       break;
        }
    }
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // Add here your progress output
    }
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Add here your completed output
    }
