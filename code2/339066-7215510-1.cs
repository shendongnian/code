     (new Thread(() => {
            DoLongRunningWork();
            MessageBox.Show("Long Running Work Finished!");
        }) { Name = "Long Running Work Thread",
            Priority = ThreadPriority.BelowNormal }).Start();
