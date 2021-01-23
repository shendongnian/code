    private void ComboBoxName_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox cbx = (ComboBox)sender;
        string s = ((DataRowView)cbx.Items.GetItemAt(cbx.SelectedIndex)).Row.ItemArray[0].ToString();
    }
