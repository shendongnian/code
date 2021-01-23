    MyObject myObject = this.MyObject;
    var bw = new BackgroundWorker();
    bw.DoWork += (sender, args) => {
        // this will happen in a separate thread
        Thread.Sleep(1000);
        DoTheCodeThatNeedsToRunAsynchronously();
    }
    bw.RunWorkerCompleted += (sender, args) => {
        // We are back in the UI thread here.
        if (args.Error != null)  // if an exception occurred during DoWork,
            MessageBox.Show(args.Error.ToString());  // do your error handling here
        else
            myObject.ChangeSomeProperty();
    }
    bw.RunWorkerAsync(); // start the background worker
