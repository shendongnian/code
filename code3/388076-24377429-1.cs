     private void OnSessionChanged(object sender, LiveConnectSessionChangedEventArgs e)
        {
            //sign in
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }
            if (e.Status == LiveConnectSessionStatus.Connected)
            {
                ((App) Application.Current).Session = e.Session;
                connectClient = new LiveConnectClient(((App) Application.Current).Session);
                           }
            }
        }
