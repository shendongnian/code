    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        foreach (System.Diagnostics.EventLogEntry entry in eventLog1.Entries)
        {
            var newEntry = entry.EntryType.ToString() + " - " + entry.TimeWritten + "     - " + entry.Source;
            Action action = () => listBox1.Items.Add(newEntry);
            Invoke(action);
        }
    }
