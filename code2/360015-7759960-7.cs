     private void ComboBox_KeyDown(object sender, KeyEventArgs e)
     {
        if (e.KeyCode == Keys.Enter)
        {
            ValidateSelection();
        }
     }
    private void ComboBox_Leave(object sender, EventArgs e)
    {
        if(!ValidateSelection())
        {
            ComboBox.Focus();
        }
     }
