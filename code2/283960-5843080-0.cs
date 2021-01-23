    private void _ws_InitializeConnexionCompleted(object sender, InitializeConnexionCompletedEventArgs e)
       {
           if (e.Error != null)
           {
               this.Member = e.Result;
               this.NavigationService.Navigate(new Uri("/View/profile.xaml", UriKind.Relative));
           }
           else
           {
               MessageBox.Show("error.");
           }
       }
    }
