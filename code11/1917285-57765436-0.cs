    private async void SignOutButton_Click(object sender, RoutedEventArgs e)
            {
                var accounts = await App.PublicClientApp.GetAccountsAsync();
                if (accounts.Any())
                {
                    try
                    {
                        
                        await App.PublicClientApp.RemoveAsync(accounts.FirstOrDefault());
                        NavigationWindow window = new NavigationWindow();
                        window.Source = new Uri("https://login.microsoftonline.com/common/oauth2/v2.0/logout");
                        window.Show();
                        this.ResultText.Text = "User has signed-out";
                        this.CallGraphButton.Visibility = Visibility.Visible;
                        this.SignOutButton.Visibility = Visibility.Collapsed;
                    }
                    catch (MsalException ex)
                    {
                        ResultText.Text = $"Error signing-out user: {ex.Message}";
                    }
                }
            }
