     private void _ws_InitializeConnexionCompleted(object sender, InitializeConnexionCompletedEventArgs e)
     {
            if (e.Error != null)
            {
                this.Member = e.Result;
                this.Navigate("/View/profile.xaml");
            }
            else
            {
                MessageBox.Show("error.");
            }
        }
    }
    
    protected void Navigate(string address)
    {
        if (string.IsNullOrEmpty(address))
              return;
    
        Uri uri = new Uri(address, UriKind.Relative);
        Debug.Assert(App.Current.RootVisual is PhoneApplicationFrame);
        ((PhoneApplicationFrame)App.Current.RootVisual).Navigate(uri);            
    }
