    private void MainWindow_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string message = sp.ReadLine();
        if (string.IsNullOrWhiteSpace(message))
            return;
        this.MessageText = message;
    }
