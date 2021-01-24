    private void OpenOptions(object sender, RoutedEventArgs e){
    RadioButton radioButton = sender as RadioButton;
            radioButton.IsChecked = true;
            //Disable all option buttons except one that active
            MyGrid.Children.OfType<RadioButton>().Where(rb => rb != radioButton && 
        rb.GroupName == radioButton.GroupName).ToList().ForEach(rb => rb.IsEnabled = false);
    }
        private void HideOptions(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            MyGrid.Children.OfType<RadioButton>().Where(rb => rb.GroupName == 
         radioButton.GroupName).ToList().ForEach(rb => rb.IsEnabled = true);
    }
