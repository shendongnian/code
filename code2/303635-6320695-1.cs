    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        foreach (System.Diagnostics.EventLogEntry entry in eventLog1.Entries)
        {
            var newEntry = entry.EntryType + " - " + entry.TimeWritten + "     - " + entry.Source;
            backgroundWorker1.ReportProgress(0, newEntry);
        }
    }
    void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var newEntry = (string)e.UserState;
        listBox1.Items.Add(newEntry);
    }
