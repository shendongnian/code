    protected void btnRun_Click(object sender, EventArgs e)
    {
        var jobState = new StateInfo()
        {
            Id = 1,
            Counter = 0,
            Content = "Start the job",
            Cancelled = false,
            Completed = false
        };
        Session["job"] = jobState;
        System.Threading.ThreadPool.QueueUserWorkItem(
            new System.Threading.WaitCallback(LongJob),
            jobState
            );//returns immediately
        lblToken.Text += "<br />" + jobState.Counter.ToString() 
            + " Completed: " + jobState.Completed.ToString()
            + " Cancelled: " + jobState.Cancelled.ToString()
            + "<br />" + jobState.Content;
        btnCancel.Visible = true;
        btnCheck.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        var jobState = Session["job"] as StateInfo;
        if (!jobState.Completed)
            jobState.Cancelled = true;
        System.Threading.Thread.Sleep(1000);//wait for the next loop to complete
        lblToken.Text += "<br />" + jobState.Counter.ToString()
            + " Completed: " + jobState.Completed.ToString()
            + " Cancelled: " + jobState.Cancelled.ToString()
            + (jobState.Completed || jobState.Cancelled ? "<br />" + jobState.Content : "");
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        var jobState = Session["job"] as StateInfo;
        lblToken.Text += "<br />" + jobState.Counter.ToString()
            + " Completed: " + jobState.Completed.ToString()
            + " Cancelled: " + jobState.Cancelled.ToString()
            + (jobState.Completed || jobState.Cancelled ? "<br />" + jobState.Content : "");
    }
    private void LongJob(object state)
    {
        var jobState = state as StateInfo;
        do
        {
            System.Threading.Thread.Sleep(1000);
            jobState.Counter++;
            if (jobState.Counter >= 100)
            {
                jobState.Completed = true;
                jobState.Content = "The job is completed";
            }
            else if (jobState.Cancelled)
                jobState.Content = "The job is cancelled";
        }
        while (!jobState.Cancelled && !jobState.Completed);
    }
    [Serializable]
    class StateInfo
    {
        public int Id { get; set; }
        public int Counter { get; set; }
        public string Content { get; set; }
        public bool Cancelled { get; set; }
        public bool Completed { get; set; }
    }
