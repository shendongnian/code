    private void UserLogoutBtn_Click(object sender, RoutedEventArgs e)       
    {
      var dialog = new Dialog() {Owner = this};
      // Returns when window is closed
      bool? dialogResult = dialog.ShowDialog();
      
      if (dialogResult.Value)
      {
        mainFrame.Content = new Page1();
      }
      else
      {
        mainFrame.Content = new Admin_Homepage();
      }
    }
