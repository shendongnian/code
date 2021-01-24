    private void Button1_Click(object sender, EventArgs e)
    {
        this.Text = YourMethod();
    }
    public static int YourMethod()
    {
        return Task.Run(async () => await ExternalMethodAsync()).Result;
    }
    public static async Task<string> ExternalMethodAsync()
    {
        Thread.Sleep(500); // Synchronous part
        await Task.Delay(500).ConfigureAwait(false); // Asynchronous part
        return $"Time: {DateTime.Now:HH:mm:ss.fff}";
    }
