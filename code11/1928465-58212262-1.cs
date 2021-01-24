    // This will run in the UI thread
    private async void Export_Execute_Click(object sender, EventArgs args)
    {
        try
        {
            var progress = new Progress<string>();
            progress.ProgressChanged += ExportProgress_ProgressChanged;
            // Task.Factory.StartNew allows to set advanced options
            await Task.Factory.StartNew(() => Do_Export(filename, classes,
                TimeZoneInfo.ConvertTimeToUtc(timestamp), progress),
                CancellationToken.None, TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
            toolStripStatusLabel.Text = $"Export completed successfully";
        }
        catch (Exception e)
        {
            toolStripStatusLabel.Text = $"Export failed: {e.Message}";
        }
    }
    // This will run in the UI thread
    private void ExportProgress_ProgressChanged(object sender, string e)
    {
        toolStripStatusLabel.Text = e;
    }
    // This will run in a dedicated background thread
    private void Do_Export(string filename, string classes, DateTime timestamp,
        IProgress<string> progress)
    {
        for (int i = 0; i < 100; i += 10)
        {
            progress?.Report($"Export {i}% percent done");
            Thread.Sleep(1000);
        }
    }
