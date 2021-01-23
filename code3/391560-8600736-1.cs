    private void btnHistory_Click(object sender, EventArgs e) 
    { 
        Class1 c = new Class1(ref label12); 
        c.StartClock(); 
        var backgroundWorker = new BackgroundWorker();
        backgroundWorker.DoWork += (s, e) =>
            {
                // time consuming function
                Utility.PopulateHistory(dgvRecords_history, _util);
            }
 
        backgroundWorker.RunWorkerCompleted += (s, e) =>
            {
                c.StopClock();
            }
        backgroundWorker.RunWorkerAsync();
    } 
