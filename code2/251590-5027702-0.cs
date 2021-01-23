    void worker_ProgressChanged(object sender, M5.Objects.Dispenser.ProgressChangedArgs e)
    {
        M5.Objects.Dispenser.Worker MyWorker = (M5.Objects.Dispenser.Worker)sender;
        MyWorker.Continue = false;
        while (MyWorker.StillRunning)
        {
            // Wait here...
        }
        // Do something else
    }
