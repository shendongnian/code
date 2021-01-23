    private void dataGridView1_EditingControlShowing(object sender, 
          DataGridViewEditingControlShowingEventArgs e)
    {
      var comboBox = e.Control as ComboBox;
      comboBox.DropDown += comboBox_DropDown;
      comboBox.DropDownClosed += comboBox_DropDownClosed;
    }
    private void comboBox_DropDown(object sender, System.EventArgs e)
    {
      var comboBox = sender as ComboBox;
      if(comboBox != null)
      {
        comboBox.DropDown -= comboBox_DropDown;
        comboBox.DisplayMember = "NameWithCode";        
      }
    }
    private void comboBox_DropDownClosed(object sender, System.EventArgs e)
    {
      var comboBox = sender as ComboBox;
      if(comboBox != null)
      {
        comboBox.DropDownClosed -= comboBox_DropDownClosed;
        var selectedItem = comboBox.SelectedItem; 
        comboBox.DisplayMember = "CustCode";
        comboBox.SelectedItem = selectedItem;        
      }
    }
