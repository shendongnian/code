    private void cmdSearch_Click(object sender, EventArgs e)
    {
        if (qFlag == QueryFlags.None)
        {
            rtfLog.AppendText("\nNo search criteria selected.");
            return;
        }
        foreach (QueryFlag flag in GetFlags(qFlag))
        {
            rtfLog.AppendText(string.Format("\nSearching {0}", flag.ToString()));
            // add switch for flag value
        }
    }
