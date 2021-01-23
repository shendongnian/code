    DownloadDataCompleted += delegate {
        progressBar.Invoke(() => {
            progressBar.Value = progressBar.Maximum;
            progressFinished = true;
        }
    };
    DownloadProgressChanged += delegate {
        progressBar.Invoke(() => {
            if (!progressFinished)
                progressBar.Value =
                      progressBar.Minimum +
                      (progressBar.Maximum - progressBar.Minimum) * progressRatio;
        }
    };
