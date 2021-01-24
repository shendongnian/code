    private CancellationTokenSource cts;
    private async void StartWork_Click( object sender, EventArgs e )
    {
        showWorkingLabel.Text = "Work started ...";
        cts = new CancellationTokenSource();
        var token = cts.Token;
        try
        {
            TestDataList = await Task.Run( () =>
            {
                return this.TestData
                    .Cast<string>()
                    .Select( ( s, i ) =>
                    {
                        token.ThrowIfCancellationRequested();
                        return new
                        {
                            GroupIndex = i / 100,
                            Item = s.Trim().ToLower()
                        };
                    } )
                    .GroupBy( g => g.GroupIndex )
                    .Select( g =>
                    {
                        token.ThrowIfCancellationRequested();
                        return string.Join( ",", g.Select( x => x.Item ) );
                    } )
                    .ToList();
            }, token );
            showWorkingLabel.Text = "Work completed.";
        }
        catch ( OperationCanceledException )
        {
            showWorkingLabel.Text = "Work canceled.";
        }
        catch ( Exception ex )
        {
            showWorkingLabel.Text = "Work faulted - " + ex.Message;
        }
    }
    private void btnCancel_Click( object sender, EventArgs e )
    {
        cts.Cancel();
        showWorkingLabel.Text = "Work cancellation requested ...";
    }
