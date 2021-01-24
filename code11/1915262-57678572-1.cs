    private void TestButton_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("My Message Question", "My Title", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            //Saveproject(); // write your save code here or call saving method and close the whole project
            Close();
        }
        else if (result == MessageBoxResult.No)
        {
            Close(); // dont do anything just close project
        }
        else if (result == MessageBoxResult.Cancel)
        {
            // you dont even need this third condition on cancel btn click only message box will close 
            //and nothing else will happen  
           // additionally you can use here
              e.Cancel = true;  
              e.Handled = true;
        }
    }
