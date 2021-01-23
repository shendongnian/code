    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        for (var i = 0; i < 1000; i++)
        {
            var myObjectInstance = new MyObject{ ...};
            backgroundWorker1.ReportProgress(null, myObjectInstance);
        }
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var myObjectInstance = (MyObject)e.UserState;
        Console.WriteLine(myObjectInstance);
    }
