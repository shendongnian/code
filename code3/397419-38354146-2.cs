    public void outputReceivedHandler(object sender, DataReceivedEventArgs e)
    {
        if (e.Data != null || !string.IsNullOrEmpty(e.Data))
            Console.WriteLine(e.Data);
    }
