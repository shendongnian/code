    private void connConnectCompleted(AsyncCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            // Something didn't work...abort captain
            CloseSocket();
            Console.WriteLine(this.GetType().ToString() + @":Error connecting socket:" +  e.Error.Message);
            return;
        }
        // Do stuff with your connection
    }
