     private void button1_Click(object sender, EventArgs e)
    {
        var tokenSource2 = new CancellationTokenSource();
        CancellationToken ct = tokenSource2.Token;
        Read(ct);
    }
    private async void Read( CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
               Thread.Sleep(4000);
        }
    }
    
