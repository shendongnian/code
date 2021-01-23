    DownloadDataCompleted += delegate {
        SafeInvoke(() => {
            progressBar.Value = progressBar.Maximum;
            progressFinished = true;
        }
    };
    DownloadProgressChanged += delegate {
        SafeInvoke(() => {
            if (!progressFinished)
                progressBar.Value =
                      progressBar.Minimum +
                      (progressBar.Maximum - progressBar.Minimum) * progressRatio;
        }
    };
