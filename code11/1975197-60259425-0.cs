    // start the loop
    private void button1_Click(object sender, EventArgs e)
    {
        LoopStopped = false;
        StartLoop();
    }
    
    // put yor while loop here
    private async void StartLoop()
    {
        await Task.Run(() =>
        {
            while (LoopStopped == false)
            {
                var date = DateTime.Now;
                System.Diagnostics.Debug.WriteLine(date);
    
            }
            System.Diagnostics.Debug.WriteLine("Thread stopped.");
        });
    }
    
    // stop the loop
    private void button2_Click(object sender, EventArgs e)
    {
        LoopStopped = true;
    }
