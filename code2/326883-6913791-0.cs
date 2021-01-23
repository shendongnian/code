    private void scheduleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        //Get the value of selected index in scheduleListBox
        int selectedIndexOfSchedule = scheduleListBox.SelectedIndex;
             
        if(selectedIndexOfSchedule != -1)
        {
            if (sortedSelectedValue.Text == "")
            {
                string selectedValueText = sortedTimeListBox.Items[selectedIndexOfSchedule].ToString();
                MessageBox.Show("selectedValueText : " + sortedSelectedValue.Text);
            }
            else
            {
                MessageBox.Show("Empty");
            }
    
            NavigationService.Navigate(new Uri("/ViewScheduleDetails.xaml?selectedIndexOfSchedule=" + selectedIndexOfSchedule + "&selectedFolderName1=" + fullFolderName + "&passToDelete=" + selectedFolderName, UriKind.Relative));
            scheduleListBox.SelectedIndex = -1;
        }
    
    }
