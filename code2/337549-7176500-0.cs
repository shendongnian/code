    protected override void OnClosing(CancelEventArgs e)
    {
        if (bWrongClose)
        {
            bWrongClose = false;
            e.Cancel = true; // this blocks the `Form` from closing
        }
        base.OnClosing(e);
    }
