    private void buttonStart_Click(object sender, EventArgs e)
    {
        BackgroundWorker bw = new BackgroundWorker();
        this.Controls.Add(bw);
        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        bw.RunWorkerAsync();
    }
    
    private bool quit = false;
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        while (!quit)
        {
            // Code to send email here
        }
    }
