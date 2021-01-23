    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
         progressRestore.IsIndeterminate = false;
         progressRestore.Value = e.ProgressPercentage;
         lblRestProgress.Content = e.ProgressPercentage + "%";
         //lblRestProgressDesc.Content = "Row " + lineCount + " of " + totalRows;
    }
