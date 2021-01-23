    private void OpenConnectionButton_Click() {
        var bw = new BackgroundWorker();
        bw.DoWork += (sender, e) => {
            // this will happen in a separate thread
            var connector = new DataConnector();
            connector.connect(); // this might take a while
            e.Result = connector;
        }
        bw.RunWorkerCompleted += (sender, e) => {
            // We are back in the UI thread here.
            // close the progress bar
            ...
            if (e.Error != null)  // if an exception occurred during DoWork,
                MessageBox.Show(e.Error.ToString());  // do your error handling here
            else {
                var connector = (DataConnector)e.Result;
                // do something with your connector
            }
        };
        // show the progress bar
        ...
        bw.RunWorkerAsync(); // start the background worker
    }
