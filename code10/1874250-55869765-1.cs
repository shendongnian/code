    private void UpdateUI()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            try
            {
                if (SecurityComponent.CurrentLoggedUser != null)
                {
                    var user = SecurityComponent.CurrentLoggedUser;
                    m_userLabel.Text = user.Username + " - " + user.Role.Name;
                }
                UpdateTerritories();
                ViewsIntegrationService.SetHmiMode(EHmiModes.Normal);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        });
    }
