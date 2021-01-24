    private void cmbPortName_SelectedIndexChanged(object sender, EventArgs e)
    {
        // This will enable the button so long as the selected value
        // is not null or an empty string.
        if (cmbPortName.SelectedItem != null && !string.IsNullOrEmpty(cmbPortName.SelectedItem.ToString()))
            btnConnect.Enabled = true;
        else
            btnConnect.Enabled = false;
    }
