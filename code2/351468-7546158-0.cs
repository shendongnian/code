    private void ApplicationBarLogin_Click(object sender, EventArgs e)
    {
        settings.UsernameSetting = Username.Text;
        if (RememberPassword.IsChecked == true)
        {
            settings.PasswordSetting = Password.Password;
            settings.RememberPasswordSetting = true;
        }
        else
        {
            settings.RememberPasswordSetting = false;
        }
    
        WebClient internode = new WebClient();
    
        internode.Credentials = new NetworkCredential(settings.UsernameSetting, settings.PasswordSetting);
        internode.DownloadStringCompleted += new DownloadStringCompletedEventHandler(internode_DownloadStringCompleted);
        internode.DownloadStringAsync(new Uri("https://customer-webtools-api.internode.on.net/api/v1.5/"));
    }
    
    private int _retryCount = 0;
        
    public void internode_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            _retryCount++;
            if (_retryCount < 3)
            {
                WebClient internode = (WebClient)sender;
                internode.DownloadStringAsync(new Uri("https://customer-webtools-api.internode.on.net/api/v1.5/"));
            }
            else
            {
                _retryCount = 0;
                MessageBox.Show(e.Error.Message);
            }
        }
        else
        {
            _retryCount = 0;
            MessageBox.Show("Authentication successfull.");
        }
    }
