    private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
    {
        //Get the item selected in the combobox
        ComboBox cbx = (ComboBox)sender;
        int idx = cbx.SelectedIndex;    
        string s1 = cbx.SelectedItem.ToString();
        // Enable the time so that the Highlight can be removed
        timer1.Enabled = true;
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
        // Remove the Highlight
        comboBox1.Select(0, 0);
        // Disable timer
        timer1.Enabled = false;
    }
