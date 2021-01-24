    private void MyCheckBox_Click(object sender, RoutedEventArgs e)
    {
        CheckBox checkBox = sender as CheckBox;
        if (checkBox.Name == "chkWeekday" && checkBox.IsChecked == true)// First demand
        {
            chkTuesday.IsChecked = chkWednesday.IsChecked = chkThursday.IsChecked = true;
        }
        else if (checkBox.Name == "chkWeekday" && checkBox.IsChecked == false) // Second demand
        {
            chkTuesday.IsChecked = chkWednesday.IsChecked = chkThursday.IsChecked = false;
        }
        else if (chkTuesday.IsChecked == true && chkWednesday.IsChecked == true && chkThursday.IsChecked == true) //Third demand
        {
            chkWeekday.IsChecked = true;
        }
        else //Fourth demand
        {
            chkWeekday.IsChecked = false;
        }
    }
