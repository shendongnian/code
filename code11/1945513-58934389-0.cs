    private CancellationTokenSource cancellationToken;
    
    //start
    private void button1_Click(object sender, EventArgs e)
    {
        cancellationToken= new CancellationTokenSource();
        Read();
    }
    private async void Read()
    {
        Task.Factory.StartNew(() =>
        {
            await Task.Delay(4000);
            listBox1.Items.Insert(0, "Read 1");
        }, cancellationToken.Token);
    }
    //stop
    private void button2_Click(object sender, EventArgs e)
    {
        if(cancellationToken!= null) 
        cancellationToken.Cancel();
    }
