     private void button1_Click(object sender, EventArgs e)
    {
        Read(true);
    }
    private async void Read( CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
               Thread.Sleep(4000);
        }
    }
    //stop
    private void button2_Click(object sender, EventArgs e)
    {
        Read(false);
    }
