    private void frmMain_Load(object sender, EventArgs e)
    {
        System.Diagnostics.EventLog s = new System.Diagnostics.EventLog("Application", ".", "");
        s.EnableRaisingEvents = true;
        s.EntryWritten += delegate(object st, System.Diagnostics.EntryWrittenEventArgs ew)
        {
            MessageBox.Show(ew.Entry.Message);
        };
    }
