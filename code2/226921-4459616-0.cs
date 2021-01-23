    AutoResetEvent resetEvent = new AutoResetEvent(false);
    private void StartProcess()
    {
        new Thread(DoProcess).Start();
    }
    private void DoProcess()
    {
        List<String> list = new List<String>() { 
            "Value 1",
            "Value 2",
            "Value 3",
            "Value 4",
            "Value 5",
        };
        foreach (String item in list)
        {
            process.RunWorkerAsync(item);
            if (!resetEvent.WaitOne())
            {
                // Some exception
                break;
            }
            resetEvent.Reset();
        }
    }
    private void process_DoWork(object sender, DoWorkEventArgs e)
    {
        Debug.WriteLine(e.Argument.ToString());
        Thread.Sleep(1000);
    }
    private void process_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        resetEvent.Set();
    }
