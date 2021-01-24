    // start the loop
    private async void button1_Click(object sender, EventArgs e)
    {
        LoopStopped = false;
        await StartLoopAsync();
    }
    
    // put yor while loop here
    private Task StartLoopAsync()
    {
        return Task.Run(() =>
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
