    private void closeButton_Click(object sender, RoutedEventArgs e)
    {
            if (MessageBox.Show("Are you sure?", "Application", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
    }
