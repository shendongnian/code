    PickerOne.SelectedIndexChanged += PickerOne_SelectedIndexChanged;
    PickerTwo.SelectedIndexChanged += PickerTwo_SelectedIndexChanged;
    
    
    void PickerOne_SelectedIndexChanged(object sender, EventArgs e)
    {
      var picker = (Picker)sender;
      int selectedIndex = picker.SelectedIndex;
    
      if (selectedIndex != -1)
      {
        PickerTwo.IsEnabled = true;
      }else{
        PickerTwo.IsEnabled = false;
      }
    }
    
    void PickerTwo_SelectedIndexChanged(object sender, EventArgs e)
    {
      var picker = (Picker)sender;
      int selectedIndex = picker.SelectedIndex;
    
      if (selectedIndex != -1)
      {
        PickerThree.IsEnabled = true;
      }else{
        PickerThree.IsEnabled = false;
      }
    }
