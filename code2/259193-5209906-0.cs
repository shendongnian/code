    protected virtual void fileSortProgressSplitting(FileSort o, double progress)
    {
        BeginInvoke( new Action( () =>
            {
                progressBar.Fraction = progress;
                progressBar.Text = "Splitting...";
            } );
    }
