    private void SetControlStates()
    {
        bool buttonEnabled = theComboBox.SelectedIndex >= 0;
        if (theButton.Enabled != buttonEnabled) theButton.Enabled = buttonEnabled;
        // code for other controls follow here
    }
