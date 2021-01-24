    private void btnSaveSettings_Click(object sender, EventArgs e)
    {
    	Properties.Settings.Default.Name = txtName.Text;
    	Properties.Settings.Default.School = txtSchool.Text;
    	Properties.Settings.Default.Class = txtClass.Text;
    	Properties.Settings.Default.Save();
    }
