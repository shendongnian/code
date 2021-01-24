    private void btnSaveSettings_Click(object sender, EventArgs e)
    {
    	Properties.Settings.Default.txtName = txtName.Text;
    	Properties.Settings.Default.txtSchool = txtSchool.Text;
        Properties.Settings.Default.txtClass = txtClass.Text;
        
        if (chkActiveStudent.Checked == true)
            {
                _loadedConfig["UserSettings"]["chkActiveStudent"] = "Checked";
            }
            else
            {
                _loadedConfig["UserSettings"]["chkActiveStudent"] = "UnChecked";
            }        
    	
    	Properties.Settings.Default.Save();
    }
