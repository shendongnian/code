    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        while (!worker.CancellationPending)
        {
            Task.Delay(1000).Wait();
            this.Invoke((MethodInvoker)delegate
            {
                this.box.Text += '.';
                this.box.Update();
            });
        }
    }
    
    private async void MakeCall()
    {
        // it'd be a good idea to disable the button here
        worker.RunWorkerAsync();
        await Task.Run(() => 
        {
            using (WebClient client = new WebClient())
            {
                var res = client.DownloadString("https://localhost:44343/api/TestDelay");
                MessageBox.Show(res);
            }
            worker.CancelAsync();
        });
        // re-enable your button here
    }
    
    private void button_Click(object sender, EventArgs e)
    {
        MakeCall();
    }
