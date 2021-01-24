       private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBox1.IsChecked == true)
            {
                _conditions["criteria1"] = string.Format("NRO Like '2%' OR NRO Like '3%'");
                UpdateFilter();
            }
            else
            {
                _conditions["criteria1"] = null;
                UpdateFilter();
            }
        }
