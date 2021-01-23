    private void button1_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync();
        MessageBox.Show("Close this message!");
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        Thread.Sleep(5000);
        SendKeys.SendWait("{Enter}");//or Esc
    }
