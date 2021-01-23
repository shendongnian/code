    Action DoWorkAction;
    
    private void button_Process_Click(object sender, EventArgs e)
    {
        gbHistory.Enabled = false;
        gbScrub.Enabled = false;
        DoWorkAction = new Action(Scrub_DoWork);
        bgWork_Process.DoWork += DoWorkAction;
        bgWork_Process.RunWorkerAsync();
    }
