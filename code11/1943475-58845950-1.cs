    private void MakeCall()
    {
        // it'd be a good idea to disable the button here
        ManualResetEventSlim waiter = new ManualResetEventSlim(false);
        Task.Run(async () => 
        {
            while(!waiter.IsSet) 
            {
                await Task.Delay(1000);  
                this.Invoke((MethodInvoker)delegate
                {
                    this.box.Text += '.';
                    this.box.Update();
                });                
            } 
        });
        Task.Run(() => 
        {
            using (WebClient client = new WebClient())
            {
                var res = client.DownloadString("https://localhost:44343/api/TestDelay");
                MessageBox.Show(res);
            }
            waiter.Set();
            // hop back on the UI thread and re-enable your button here
        });
    }
    
    private void button_Click(object sender, EventArgs e)
    {
        MakeCall();
    }
