    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
    	this.colStatus.Visibility = System.Windows.Visibility.Visible;
    }
    
    private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
    {
    	this.colStatus.Visibility = System.Windows.Visibility.Collapsed;
    }
