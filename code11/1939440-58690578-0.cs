    private CancellationTokenSource cancellationTokenSource;
    
    private void button1_Click(object sender, EventArgs e)
    {
        // create a new CancellationTokenSource and Token for this event
        cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        string filename = @"temp1.txt";
        int n = 5;
        foreach (var line in File.ReadLines(filename).AsParallel().WithDegreeOfParallelism(n))
        {
            textBox1.Text = line;
    
            // Check if token has had a requested cancellation.
            if (cancellationToken.IsCancellationRequested)
                break;
        }
    }
    
    private void button4_Click(object sender, EventArgs e)
    {
        if (cancellationTokenSource != null)
            cancellationTokenSource.Cancel();
    }
