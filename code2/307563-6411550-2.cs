    private void btnBackgroundworker_Click(object sender, EventArgs e)
    {
        BackgroundWorker bg = new BackgroundWorker();
        bg.DoWork += bg_DoWork;
        bg.RunWorkerAsync();
    }
    private delegate void UpdateUIDelegate();
    void bg_DoWork(object sender, DoWorkEventArgs e)
    {
        listBox1.Invoke(new UpdateUIDelegate(UpdateListBox));
    }
    private void UpdateListBox()
    {
        carList.Add(new Car { CarName = "BarFromBackgroundWorkerThread" });
    }
