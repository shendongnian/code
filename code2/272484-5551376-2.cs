    public void start()
    {
        var bw = new BackgroundWorker();
        // define the event handlers
        bw.DoWork += (sender, args) => {
            // do your lengthy stuff here -- this will happen in a separate thread
            ...
        }; //dont forget semi colon
        bw.RunWorkerCompleted += (sender, args) => {
            if (args.Error != null)  // if an exception occurred during DoWork,
                MessageBox.Show(args.Error.ToString());  // do your error handling here
            // Do whatever else you want to do after the work completed.
            // This happens in the main UI thread.
            ...
        }; //dont forget semi colon
        bw.RunWorkerAsync(); // starts the background worker
        // execution continues here in parallel to the background worker
    }
