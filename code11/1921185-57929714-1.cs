    private void comComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(comComboBox.SelectedItem != null)
        {
            ControlP p = comComboBox.SelectedItem as ControlP;
            notTextBox.Text = p.Not;
            priTextBox.Text = p.Pri;
        }     
    }
