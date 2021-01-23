    bool mySettingSelectionChangedInCode;
    private void SetMySettingComboBox(string value)
    {
        mySettingSelectionChangedInCode = true;
        mySettingComboBox.SelectedItem = value;
        mySettingSelectionChangedInCode = false;
    }
    private void mySettingComboBox_SelectionChanged(object sender, EventArgs args)
    {
        if (mySettingSelectionChangedInCode)
            return;
        //...
    }
    
