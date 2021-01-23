    private void TargetsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var listBox = sender as ListBox;
        
        var selectedItem = listBox.SelectedItem as Player;
        if (selectedItem != null)
        {
            string id = selectedItem.PlayerID
            string nick = selectedItem.NickName;
        }
    }
