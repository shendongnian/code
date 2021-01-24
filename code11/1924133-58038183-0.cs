    // We need to remember the BackgroundWorker
    private BackgroundWorker bw;
    private void StartWork_Click( object sender, EventArgs e )
    {
        bw = new BackgroundWorker
        {
            WorkerSupportsCancellation = true,
        };
        bw.DoWork += Bw_DoWork;
        bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
        bw.RunWorkerAsync();
        showWorkingLabel.Text = "Work started ...";
    }
    private void Bw_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
    {
        if ( e.Cancelled ) // was it cancelled?
        {
            showWorkingLabel.Text = "Work cancelled.";
            return;
        }
        if ( e.Error != null ) // any error?
        {
            showWorkingLabel.Text = "Work faulted - " + e.Error.Message;
            return;
        }
        // assign the bw Result to the field
        this.TestDataList = (List<string>)e.Result;
        showWorkingLabel.Text = "Work completed.";
    }
    private void Bw_DoWork( object sender, DoWorkEventArgs e )
    {
        try
        {
            e.Result = this.TestData
                .Cast<string>()
                .Select( ( s, i ) =>
                {
                    // check for cancellation
                    if ( bw.CancellationPending )
                        throw new OperationCanceledException();
                    return new
                    {
                        GroupIndex = i / 100,
                        Item = s.Trim().ToLower()
                    };
                } )
                .GroupBy( g => g.GroupIndex )
                .Select( g =>
                {
                    // check for cancellation
                    if ( bw.CancellationPending )
                        throw new OperationCanceledException();
                    return string.Join( ",", g.Select( x => x.Item ) );
                } )
                .ToList();
        }
        catch ( OperationCanceledException )
        {
            e.Cancel = true;
        }
    }
    private void btnCancel_Click( object sender, EventArgs e )
    {
        // request cancellation
        bw.CancelAsync();
        showWorkingLabel.Text = "Work cancellation requested ...";
    }
