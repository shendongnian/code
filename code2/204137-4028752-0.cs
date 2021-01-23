    private void dataGridView1_EditingControlShowing(object sender, 
        DataGridViewEditingControlShowingEventArgs e)
    {
        var comboBox = e.Control as ComboBox;
    
        comboBox.DropDown += (s1, e1) => comboBox.DisplayMember = "NameWithCode";
    
        comboBox.DropDownClosed += (s2, e2) =>
            {
                // save the last selected item to return it after 
                // reassign the Display Member
                var selectedItem = comboBox.SelectedItem; 
    
                comboBox.DisplayMember = "CustCode";
                comboBox.SelectedItem = selectedItem;
            };
    }
