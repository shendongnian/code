    private void UserLogoutBtn_Click(object sender, RoutedEventArgs e)       
    {
      var dialog = new Dialog() {Owner = this};
      // Returns when the dialog window was closed
      bool? dialogResult = dialog.ShowDialog();
      
      if (dialogResult.Value)
      {
        // Ok was clicked
        var mainWin = new Page();
        NavigationService.Navigate(mainWin);
      }
      else
      {
        // Cancel was clicked or the window was closed
      }
    }
