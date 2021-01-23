    private void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
    
        Console.WriteLine("First Message");
    
        Thread.Sleep(2000);
    
        Console.WriteLine("second Message");
    
        button1.Enabled = true;
    }
