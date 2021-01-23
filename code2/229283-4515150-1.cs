    using (var progressDialog = new ProgressDialog()) {
        progressDialog.TopMost = true;
    
        System.Threading.ThreadPool.QueueUserWorkItem((x) =>
        {
            try {
                // this represents whatever loop you use to load the file
                while (...) {
                    // do some work loading the file
    
                    // update the status
                    progressDialog.Invoke(() => progressDialog.Message = "Hello, World!");
                }
            } finally {
                // done working
                progressDialog.Invoke((Action)progressDialog.Close);
            }
        });
    
        // this will block until the thread closes the dialog
        progressDialog.ShowDialog();
    }
