    private async void Window_ContentRendered(object sender, System.EventArgs e)
    {
       await Task.Run(() =>
             {
                ConnectionState = false;
    
                if (NetworkTools.CheckGlobalConnection() == (ConnectionStatus.NetworkConnectionSuccess, ConnectionStatus.ServerConnectionSuccess))
                   ConnectionState = true;
             });
    
       this.Close();
    }
