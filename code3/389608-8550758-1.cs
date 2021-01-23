    static async void HandleClick(object sender, EventArgs e)
    {
        Console.WriteLine("In click handler");
        Button button = (Button) sender;
        button.Enabled = false;
        // Delay by 10 seconds, but without blocking the UI thread
        await TaskEx.Delay(10000);
        button.Enabled = true;        
        Console.WriteLine("Finishing click handler");
    }
