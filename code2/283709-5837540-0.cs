     private void btnLoadMyData_Click(object sender, RoutedEventArgs e)
     {
          try
          {
              LoadMyData();
          }
          catch (Exception err)
          {
              // Oops something bad happened show err.
          }
     }
     private void LoadMyData()
     {
          DataItemsListBox.ItemsSource = DownloadYourDataObjects(someUri);
     }
