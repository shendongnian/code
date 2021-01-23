    void CheckBox_Loaded(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if(checkMode.Equals("all"))
            {
                 checkBox.IsChecked = true;
            } 
        }
