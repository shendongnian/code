    public void OnApplicationExit(object sender, EventArgs e)
    {
        try
        {
            Console.WriteLine("The application is shutting down.");
        }
        catch(NotSupportedException)
        {
        }
    }
