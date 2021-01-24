    private void btnSaveSettings_Click(object sender, EventArgs e)
    {
    	Properties.Settings.Default.txtName = txtName.Text;
    	Properties.Settings.Default.txtSchool = txtSchool.Text;
    	Properties.Settings.Default.txtClass = txtClass.Text;
    	Properties.Settings.Default.Save();
    }
