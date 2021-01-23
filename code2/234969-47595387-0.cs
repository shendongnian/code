    var dgv = new DataGridView();
    System.Timers.Timer timer = new System.Timers.Timer();
    timer.Interval = 1000;
    timer.SynchronizingObject = dgv;  // syncronise
    timer.Start();
    timer.Elapsed += Timer_Elapsed;
    void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        refreshDGV();  // in here I refresh the DataGridView
    }
